using System;

//Cassandra Haydock - 2022
namespace StarbTips
{
    //Node structure
    public class Node
    {
        public Node next;
        public Node previous;
        public Workers data;
    }

    public class DoublyLinkedList
    {
        private Node head;
        private Node tail;
        private int count = 0;
        private double TippableHours = 0;
        private double DistributedTips = 0;

        //constructor to create an empty LinkedList
        public DoublyLinkedList()
        {
            head = null;
            tail = null;
        }

        //AddLast() - add elements at end of list
        public void AddLast(Workers data)
        {
            //if nothing in the list add to head which also equals tail
            if (head == null)
            {
                head = new Node();
                head.data = data;
                head.next = null;
                head.previous = null;
                tail = head;
                count++;
            }

            //else add to tail
            else
            {
                Node toAdd = new Node();
                toAdd.data = data;

                toAdd.previous = tail;
                tail.next = toAdd;
                tail = toAdd;
                count++;
            }
        }

        //GetCount() - returns the count that is tracked in other methods
        private int GetCount()
        {
            return count;
        }

        //Delete() - finds and deletes the passed target
        public void Delete(string target)
        {
            //if the head is the only thing in the list make head null
            if (head.next == null)
            {
                Console.WriteLine("The employee {0} has been deleted", head.data.Name);
                head = null;
                tail = null;
                count--;
            }

            //if there are other things in the list and head isthe target make it null and set the next to head
            else if (head.data.Name == target)
            {
                Console.WriteLine("The employee {0} has been deleted", head.data.Name);
                head = head.next;
                head.previous = null;
                count--;
            }

            //if the tail is the target make it null and make tail previous the new tail
            else if (tail.data.Name == target)
            {
                Console.WriteLine("The employee {0} has been deleted", tail.data.Name);
                tail = tail.previous;
                tail.next = null;
                count--;
            }

            //if its in the middle find the target, make it null and set the new previous and nexts
            else
            {
                Node delete = head;
                while (delete.data.Name != target)
                {
                    delete = delete.next;
                }
                Console.WriteLine("The employee {0} has been deleted", delete.previous.next.data.Name);
                delete.previous.next = delete.next;
                delete.next.previous = delete.previous;

                delete = null;
                count--;
            }
        }

        //UpdateHoursAll() - traverse the list of employess prompting the user to update them all
        public void UpdateHoursAll()
        {
            Node temp = head;
            while(temp != null)
            {
                Console.Write("Enter the hours for {0} --> ", temp.data.Name.ToString());
                double hours = Convert.ToDouble(Console.ReadLine());
                temp.data.Hours = hours;
                TippableHours += hours;
                temp = temp.next;
            }
            Console.WriteLine("Complete!");
        }

        //UpdateHoursOne() - find the employee with the target name and prompts the user to update their hours
        public void UpdateHoursOne(string target)
        {
            Node temp = head;
            //while the tempo node name from data doesnt match the string
            //and we havent traversed the whole list yet
            while(temp.data.Name != target && temp != null)
            {
                temp = temp.next;
            }

            //if we have reached the end of the list with no match its not there
            if(temp.next == null)
            {
                Console.WriteLine("There is no employee by that name in the system :(");
            }
            //else prompt to change hours
            else
            {
                Console.Write("Enter the hours for {0} --> ", temp.data.Name.ToString());
                double hours = Convert.ToDouble(Console.ReadLine());
                temp.data.Hours = hours;
                TippableHours += hours;
                Console.WriteLine("Complete!");
            }
        }

        //DisplayAll() - prints all the Nodes in order
        public void DisplayAll()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.WriteLine("{0} ----> Hours: {1}       Tips($): {2}       Distirbuted: {3}", temp.data.Name, temp.data.Hours, temp.data.Tips, temp.data.Distrubuted);
                temp = temp.next;
            }

            Console.WriteLine("Total Amount of Hours Worked ---> {0}", TippableHours);
        }

        public void TipDistribution()
        {
            Console.WriteLine();
            int twenty, ten, five, two, one, cents25, cents10, cents05;
            //Prompts the users to enter number of each bill or coin
            Console.Write("Enter the number of $20 bills --> ");
            twenty = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the number of $10 bills --> ");
            ten = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the number of $5 bills --> ");
            five = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the number of toonies --> ");
            two = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the number of loonies --> ");
            one = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the number of quarters --> ");
            cents25 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the number of dimes --> ");
            cents10 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the number of nickels --> ");
            cents05 = Convert.ToInt32(Console.ReadLine());

            //caluclate the total amount of tips
            double TotalTips = (20 * twenty) + (10 * ten) + (5 * five) + (2 * two) + one + (0.25 * cents25) + (0.10 * cents10) + (0.05 * cents05);
            //calculate the tip rate by dividing the total amount of tips by the amount of hours worked by the employees
            double TipRate = TotalTips / TippableHours;

            Node temp = head;
            while(temp != null)
            {
                temp.data.Tips = Math.Round(temp.data.Hours * TipRate);
                DistributedTips += temp.data.Tips;
                temp.data.Distrubuted = true;

                Console.WriteLine();
                Console.WriteLine("{0} -----> ${1}", temp.data.Name, temp.data.Tips);
                temp = temp.next;
            }

            Console.WriteLine();
            Console.WriteLine("Distributed Tips($) {0}", DistributedTips);
            Console.WriteLine("Tips Carried Over($) {0}", TotalTips-DistributedTips);

        }

    }
}
