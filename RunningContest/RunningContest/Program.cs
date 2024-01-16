using System;

namespace RunningContest
{
    struct Contestant
    {
        public string Name;
        public string Country;
        public double Time;

        public Contestant(string name, string country, double time)
        {
            this.Name = name;
            this.Country = country;
            this.Time = time;
        }
    }

    struct ContestRanking
    {
        public Contestant[] Contestants;
    }

    struct Contest
    {
        public ContestRanking[] Series;
        public ContestRanking GeneralRanking;
    }

    class Program
    {
        static void Main()
        {
            Contest contest = ReadContestSeries();
            GenerateGeneralRanking(ref contest);
            Print(contest.GeneralRanking);
            Console.Read();
        }

        private static void Print(ContestRanking contestRanking)
        {
            for (int i = 0; i < contestRanking.Contestants.Length; i++)
            {
                Contestant contestant = contestRanking.Contestants[i];
                const string line = "{0} - {1} - {2:F3}";
                Console.WriteLine(string.Format(line, contestant.Name, contestant.Country, contestant.Time));
            }
        }

        static void GenerateGeneralRanking(ref Contest contest)
        {
            int seriesLenght = contest.Series.Length;
            int contestansLenght = contest.Series[0].Contestants.Length;
            int generalRankingIndex = 0;
            contest.GeneralRanking = new ContestRanking
            {
                Contestants = new Contestant[seriesLenght * contestansLenght]
            };

            for (int i = 0; i < seriesLenght; i++)
            {
                for (int j = 0; j < contestansLenght; j++)
                {
                    contest.GeneralRanking.Contestants[generalRankingIndex] = contest.Series[i].Contestants[j];
                    generalRankingIndex++;
                }
            }

            MergeSort(contest.GeneralRanking.Contestants);
        }

        private static void MergeSort(Contestant[] allContestans)
        {
            Contestant[] temp = new Contestant[allContestans.Length];
            MergeSortHelper(allContestans, 0, allContestans.Length - 1, temp);
        }

        static void MergeSortHelper(Contestant[] allContestans, int left, int right, Contestant[] temp)
        {
            if (left >= right)
            {
                return;
            }

            int mid = (left + right) / 2;
            MergeSortHelper(allContestans, left, mid, temp);
            MergeSortHelper(allContestans, mid + 1, right, temp);
            Merge(allContestans, left, mid, right, temp);
        }

        static void Merge(Contestant[] allContestans, int left, int mid, int right, Contestant[] temp)
        {
            int i = left;
            int j = mid + 1;
            int k = 0;

            while (i <= mid && j <= right)
            {
                temp[k++] = allContestans[i].Time < allContestans[j].Time ? allContestans[i++] : allContestans[j++];
            }

            while (i <= mid)
            {
                temp[k++] = allContestans[i++];
            }

            while (j <= right)
            {
                temp[k++] = allContestans[j++];
            }

            for (i = left, k = 0; i <= right; i++, k++)
            {
                allContestans[i] = temp[k];
            }
        }

        static Contest ReadContestSeries()
        {
            Contest contest = new Contest();

            int seriesNumber = Convert.ToInt32(Console.ReadLine());
            int contestantsPerSeries = Convert.ToInt32(Console.ReadLine());

            contest.Series = new ContestRanking[seriesNumber];

            for (int i = 0; i < seriesNumber; i++)
            {
                contest.Series[i].Contestants = new Contestant[contestantsPerSeries];
                for (int j = 0; j < contestantsPerSeries; j++)
                {
                    string contestantLine = "";

                    while (contestantLine == "")
                    {
                        contestantLine = Console.ReadLine();
                    }

                    contest.Series[i].Contestants[j] = CreateContestant(contestantLine.Split('-'));
                }
            }

            return contest;
        }

        private static Contestant CreateContestant(string[] contestantData)
        {
            const int nameIndex = 0;
            const int countryIndex = 1;
            const int timeIndex = 2;

            return new Contestant(
                contestantData[nameIndex].Trim(),
                contestantData[countryIndex].Trim(),
                Convert.ToDouble(contestantData[timeIndex]));
        }
    }
}
