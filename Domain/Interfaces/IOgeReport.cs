using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IOgeReport
    {
        Dictionary<int, double> NumberOfPointsDict { get; set; }

        Dictionary<int, double> PercentDict { get; set; }

        Dictionary<int, double> MarksDict { get; set; }

        double GPA { get; set; }

        int NumberOfParticipants { get; set; }

        int Max { get; set; }

        int Min { get; set; }

        bool Report(string fileName);
    }
}
