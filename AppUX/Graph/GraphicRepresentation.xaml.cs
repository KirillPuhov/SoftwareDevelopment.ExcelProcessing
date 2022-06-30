using AppUX.Constants;
using AppUX.Graph.Commands;
using AppUX.Services;
using AppUX.Theme.Window;
using Domain.Managers;
using System;
using System.IO;

namespace AppUX.Graph
{
    public partial class GraphicRepresentation : RayeWindow
    {
        private readonly GraphicViewModel _viewModel;

        public GraphicRepresentation()
        {
            InitializeComponent();
            _viewModel = new GraphicViewModel(new DialogService(this), new OgeReport(AppConstants.OgeReportsModelList));

            DataContext = _viewModel;
            GraphCreation();
        }

        private void GraphCreation()
        {
            var _bar = Graph.Plot.AddBar(_viewModel.Values, _viewModel.Positions);
            _bar.Color = System.Drawing.Color.FromArgb(20,0,0,0);
            _bar.ShowValuesAboveBars = true;
            Func<double, string> _customFormatter = value => value + "%";
            _bar.ValueFormatter = _customFormatter;

            Graph.Plot.XTicks(_viewModel.Positions, _viewModel.Labels);
            Graph.Plot.SetAxisLimits(yMin: 0);

            if (!Directory.Exists(@"./graphs/"))
                Directory.CreateDirectory(@"./graphs/");

            Graph.Plot.SaveFig(@"./graphs/graph.png", 800, 400, false, 2);

            Graph.Refresh();
        }
    }
}
