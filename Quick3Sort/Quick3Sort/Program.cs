using System;

namespace Quick3Sort
{
    enum PriorityLevel
    {
        Critical,
        Important,
        Medium,
        Low
    }

    struct SupportTicket
    {
        public long Id;
        public string Description;
        public PriorityLevel Priority;

        public SupportTicket(long id, string description, PriorityLevel priority)
        {
            this.Id = id;
            this.Description = description;
            this.Priority = priority;
        }
    }

    class Program
    {
        private static void Quick3Sort(SupportTicket[] tickets, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int[] indices = Partition(tickets, left, right);
            Quick3Sort(tickets, left, indices[0] - 1);
            Quick3Sort(tickets, indices[1] + 1, right);
        }

        private static int[] Partition(SupportTicket[] tickets, int left, int right)
        {
            SupportTicket pivot = tickets[left];
            int i = left + 1;
            int lt = left;
            int gt = right;
            int[] result = new int[2];
            while (i <= gt)
            {
                if ((int)tickets[i].Priority < (int)pivot.Priority)
                {
                    Swap(tickets, i++, lt++);
                }
                else if ((int)tickets[i].Priority > (int)pivot.Priority)
                {
                    Swap(tickets, i, gt--);
                }
                else
                {
                    i++;
                }
            }

            result[0] = lt;
            result[1] = gt;
            return result;
        }

        private static void Swap(SupportTicket[] tickets, int i, int j)
        {
            SupportTicket temp = tickets[i];
            tickets[i] = tickets[j];
            tickets[j] = temp;
        }

        static void Print(SupportTicket[] tickets)
        {
            for (int i = 0; i < tickets.Length; i++)
            {
                Console.WriteLine(tickets[i].Id + " - " + tickets[i].Description + " - " + tickets[i].Priority);
            }
        }

        static SupportTicket[] ReadSupportTickets()
        {
            const int ticketIdIndex = 0;
            const int descriptionIndex = 1;
            const int priorityLevelIndex = 2;

            int ticketsNumber = Convert.ToInt32(Console.ReadLine());
            SupportTicket[] result = new SupportTicket[ticketsNumber];

            for (int i = 0; i < ticketsNumber; i++)
            {
                string[] ticketData = Console.ReadLine().Split('-');
                long id = Convert.ToInt64(ticketData[ticketIdIndex]);
                result[i] = new SupportTicket(id, ticketData[descriptionIndex].Trim(), GetPriorityLevel(ticketData[priorityLevelIndex]));
            }

            return result;
        }

        static PriorityLevel GetPriorityLevel(string priority)
        {
            return priority.ToLower().Trim() switch
            {
                "critical" => PriorityLevel.Critical,
                "important" => PriorityLevel.Important,
                "medium" => PriorityLevel.Medium,
                _ => PriorityLevel.Low,
            };
        }

        static void Main()
        {
            SupportTicket[] tickets = ReadSupportTickets();
            Quick3Sort(tickets, 0, tickets.Length - 1);
            Print(tickets);
            Console.Read();
        }
    }
}