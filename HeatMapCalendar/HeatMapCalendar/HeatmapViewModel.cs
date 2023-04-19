namespace HeatMapCalendar;

public class HeatmapViewModel
{
    public List<SupportDetails> SupportDetails { get; set; }

    public DateTime MaxDate { get; set; }

    public HeatmapViewModel()
    {
        this.MaxDate = DateTime.Today;
        this.GenerateSupportDetails();
    }

    private void GenerateSupportDetails()
    {
        this.SupportDetails = new List<SupportDetails>();
        for (int startDate = -100; startDate <= 0; startDate++)
        {
            DateTime date = DateTime.Today.AddDays(startDate);
            int supportCount = this.GetSupportCount(date);
            SupportDetails supportDetails = new SupportDetails()
            {
                Date = date,
                SupportCount = supportCount
            };
            this.SupportDetails.Add(supportDetails);
        }
    }

    private int GetSupportCount(DateTime date)
    {
        if (date.Month % 2 == 0)
        {
            if (date.Day % 6 == 0)
            {
                // 6, 12, 18, 24, 30
                return 2248;
            }
            else if (date.Day % 5 == 0)
            {
                // 5, 10, 15, 20, 25
                return 1364;
            }
            else if (date.Day % 4 == 0)
            {
                //  4, 8, 16, 24, 28
                return 1976;
            }
            else if (date.Day % 3 == 0)
            {
                // 3, 9, 18, 21, 27
                return 417;
            }
            else
            {
                // 1, 2, 7, 11, 13, 19, 22, 23, 26, 29
                return 891;
            }
        }
        else
        {
            if (date.Day % 6 == 0)
            {
                // 6, 12, 18, 24, 30
                return 891;
            }
            else if (date.Day % 5 == 0)
            {
                // 5, 10, 15, 20, 25
                return 417;
            }
            else if (date.Day % 4 == 0)
            {
                //  4, 8, 16, 24, 28
                return 1364;
            }
            else if (date.Day % 3 == 0)
            {
                // 3, 9, 18, 21, 27
                return 2248;
            }
            else
            {
                // 1, 2, 7, 11, 13, 19, 22, 23, 26, 29
                return 1976;
            }
        }
    }
}