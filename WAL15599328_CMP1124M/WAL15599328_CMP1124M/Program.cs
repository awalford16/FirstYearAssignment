using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAL15599328_CMP1124M
{
    class Data
    {
        public int MonthID { get; set; }
        public int Day { get; set; }
        public double Depth { get; set; }
        public int IRIS_ID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Magnitude { get; set; }
        public string Month { get; set; }
        public string Region { get; set; }
        public string Time { get; set; }
        public int Timestamp { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return Year + "\t| " +Month + "\t| " + Day + "\t| " + Time + "\t| " + Magnitude + "\t| " +
                Latitude + "\t| " + Longitude + "\t| " + Depth + "\t| " + Region + "\t| " +  IRIS_ID + "\t| " + Timestamp;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            bool replay = false;
            do
            {
                Sort sort = new Sort();

                //array of all possible data files
                string[] attributes = new string[]
                {
                    "Day", "Depth", "IRIS_ID", "Latitude", "Longitude", "Magnitude", "Month", "Region", "Time", "Timestamp", "Year"
                };

                List<Data> DataCollection = new List<Data>();

                //initialise size of list
                string[] dataSize = File.ReadAllLines("Day_1.txt").ToArray();

                //User choses which data to load
                Console.Write("Enter 1 to load first set of data or any character for second set: ");
                string UserChoice = Console.ReadLine();

            
                if (UserChoice == "1")
                {
                    //create array for all data files
                    //convert string[], from file reader, to int[]
                    string[] daysString = File.ReadAllLines("Day_1.txt").ToArray();
                    int[] days = daysString.Select(n => Convert.ToInt32(n)).ToArray();

                    string[] depthString = File.ReadAllLines("Depth_1.txt").ToArray();
                    double[] depth = depthString.Select(n => Convert.ToDouble(n)).ToArray();

                    string[] IrisString = File.ReadAllLines("IRIS_ID_1.txt").ToArray();
                    int[] iris = IrisString.Select(n => Convert.ToInt32(n)).ToArray();

                    string[] latString = File.ReadAllLines("Latitude_1.txt").ToArray();
                    double[] lat = latString.Select(n => Convert.ToDouble(n)).ToArray();

                    string[] lonString = File.ReadAllLines("Longitude_1.txt").ToArray();
                    double[] lon = lonString.Select(n => Convert.ToDouble(n)).ToArray();

                    string[] magString = File.ReadAllLines("Magnitude_1.txt").ToArray();
                    double[] mag = magString.Select(n => Convert.ToDouble(n)).ToArray();

                    string[] month = File.ReadAllLines("Month_1.txt").ToArray();
                    string[] region = File.ReadAllLines("Region_1.txt").ToArray();
                    string[] time = File.ReadAllLines("Time_1.txt").ToArray();

                    string[] timeString = File.ReadAllLines("Timestamp_1.txt").ToArray();
                    int[] timestamp = timeString.Select(n => Convert.ToInt32(n)).ToArray();

                    string[] yearString = File.ReadAllLines("Year_1.txt").ToArray();
                    int[] year = yearString.Select(n => Convert.ToInt32(n)).ToArray();

                    for (int i = 0; i < dataSize.Length; i++)
                    {
                        //add data to list
                        DataCollection.Add(new Data()
                        {
                            Day = days[i],
                            Depth = depth[i],
                            IRIS_ID = iris[i],
                            Latitude = lat[i],
                            Longitude = lon[i],
                            Magnitude = mag[i],
                            Month = month[i],
                            Region = region[i],
                            Time = time[i],
                            Timestamp = timestamp[i],
                            Year = year[i]
                        });
                    }
                }
                else
                {
                    //create array for all data files
                    //convert string[], from file reader, to int[]
                    string[] daysString = File.ReadAllLines("Day_2.txt").ToArray();
                    int[] days = daysString.Select(n => Convert.ToInt32(n)).ToArray();

                    string[] depthString = File.ReadAllLines("Depth_2.txt").ToArray();
                    double[] depth = depthString.Select(n => Convert.ToDouble(n)).ToArray();

                    string[] IrisString = File.ReadAllLines("IRIS_ID_2.txt").ToArray();
                    int[] iris = IrisString.Select(n => Convert.ToInt32(n)).ToArray();

                    string[] latString = File.ReadAllLines("Latitude_2.txt").ToArray();
                    double[] lat = latString.Select(n => Convert.ToDouble(n)).ToArray();

                    string[] lonString = File.ReadAllLines("Longitude_2.txt").ToArray();
                    double[] lon = lonString.Select(n => Convert.ToDouble(n)).ToArray();

                    string[] magString = File.ReadAllLines("Magnitude_2.txt").ToArray();
                    double[] mag = magString.Select(n => Convert.ToDouble(n)).ToArray();

                    string[] month = File.ReadAllLines("Month_2.txt").ToArray();
                    string[] region = File.ReadAllLines("Region_2.txt").ToArray();
                    string[] time = File.ReadAllLines("Time_2.txt").ToArray();

                    string[] timeString = File.ReadAllLines("Timestamp_2.txt").ToArray();
                    int[] timestamp = timeString.Select(n => Convert.ToInt32(n)).ToArray();

                    string[] yearString = File.ReadAllLines("Year_2.txt").ToArray();
                    int[] year = yearString.Select(n => Convert.ToInt32(n)).ToArray();

                    for (int i = 0; i < dataSize.Length; i++)
                    {
                        //add data to list
                        DataCollection.Add(new Data()
                        {
                            Day = days[i],
                            Depth = depth[i],
                            IRIS_ID = iris[i],
                            Latitude = lat[i],
                            Longitude = lon[i],
                            Magnitude = mag[i],
                            Month = month[i],
                            Region = region[i],
                            Time = time[i],
                            Timestamp = timestamp[i],
                            Year = year[i]
                        });
                
                    }
            }

            //list to not be sorted
            List<Data> UnsortedList = DataCollection;

            //output the selected data
            foreach (Data d in DataCollection)
                Console.WriteLine(d);

            //declare variables and arrays
            string[] StringData = new string[] { };
            var SortInput = 0;

            
                Console.WriteLine();
                //output possible sorting options
                for (int i = 0; i < attributes.Length; i++)
                {
                    Console.WriteLine((i + 1) + ") " + attributes[i]);
                }


                //define whether data file is integer
                bool IsIntData = false;
                bool AcceptInput = false;
                bool IsDoubleData = false;
                bool OrderInput = false;
                string orderChoice;
            
                do
                {
                    //user decision on how to sort data
                    Console.Write("Select a number related to how you would like to sort the data: ");
                    SortInput = Convert.ToInt32(Console.ReadLine());

                    //determine input
                    switch (SortInput)
                    {
                        //Sorting cases for integers
                        case 1:
                        case 3:
                        case 10:
                        case 11:
                            sort.InsertionSort(DataCollection, SortInput);
                            IsIntData = true;
                            AcceptInput = true;
                            break;
                        //sorting cases for doubles
                        case 2:
                        case 4:
                        case 5:
                        case 6:
                            sort.InsertionSort(DataCollection, SortInput);
                            IsDoubleData = true;
                            AcceptInput = true;
                            break;
                        case 7:
                            //sort months
                            sort.SortMonths(DataCollection, false);
                            IsIntData = false;
                            AcceptInput = true;
                            break;
                        case 8:
                        case 9:
                            sort.QuicksortString(DataCollection, 0, DataCollection.Count - 1, SortInput);
                            IsIntData = false;
                            AcceptInput = true;
                            break;
                        default:
                            Console.WriteLine("Sorry, the input was not understood...");
                            AcceptInput = false;
                            break;
                    }
                }
                while (AcceptInput == false && OrderInput == false);

                Console.Write("\nInput a value to search {0}s, (Enter M for maximum, and m for minimum) or press enter to display all: ", attributes[SortInput - 1]);
                var SearchInput = Console.ReadLine();

                Search search = new Search();
                bool IntInput = true;

                //use appropriate search function
                if ((IsIntData == true || IsDoubleData == true) && SearchInput != "" && SearchInput != "M" && SearchInput != "m")
                {
                    do
                    {
                        Console.WriteLine("Which searching algorithm do you wish to use? \n1.Linear\n2.Binary\n3.Interpolation");
                        try
                        {
                            int SearchChoice = Convert.ToInt32(Console.ReadLine());

                            switch(SearchChoice)
                            {
                                case 1:
                                    //binary search
                                    double searchValue = Convert.ToDouble(SearchInput);
                                    search.LinearSearch(DataCollection, searchValue);
                                    IntInput = true;
                                    break;
                                case 2:
                                    //binary search option
                                    searchValue = Convert.ToDouble(SearchInput);
                                    search.BinarySearch(DataCollection, searchValue, SortInput);
                                    IntInput = true;
                                    break;
                                case 3:
                                    //interpolation search option
                                    searchValue = Convert.ToDouble(SearchInput);
                                    search.InterpolationSearch(DataCollection, searchValue, SortInput);
                                    IntInput = true;
                                    break;
                                default:
                                    Console.WriteLine("Sorry, the number you entered is not a valid option.");
                                    IntInput = false;
                                    continue;
                            }
                        }catch(Exception)
                        {
                            Console.WriteLine("Please enter a valid integer...");
                            IntInput = false;
                            continue;
                        }

                    } while (IntInput == false);
                }
                else if (SearchInput == "")
                {
                    do
                    {
                        //output all sorted data
                        Console.WriteLine("Enter R to sort data in reverse order, or I for incrementing order...");
                        orderChoice = Console.ReadLine();
                        switch (orderChoice)
                        {
                            case "R":
                            case "r":
                                if (IsIntData == true || IsDoubleData == true)
                                    sort.ReverseInsertion(DataCollection, SortInput);
                                else if (SortInput == 7)
                                {
                                    sort.SortMonths(DataCollection, true);
                                }
                                else
                                    sort.ReverseSort(DataCollection, 0, DataCollection.Count - 1, SortInput);
                                OrderInput = true;
                                break;
                            case "I":
                            case "i":
                                //do nothing
                                OrderInput = true;
                                break;
                            default:
                                Console.WriteLine("Input not understood, please enter I or R...");
                                OrderInput = false;
                                break;
                        }
                    } while (OrderInput == false);

                    foreach (Data d in DataCollection)
                    {
                        Console.WriteLine(d);
                    }
                }
                else if (SearchInput == "M")
                {
                    //find maximum value for integer and double data
                    Console.WriteLine(DataCollection[DataCollection.Count - 1]);
                }
                else if (SearchInput == "m")
                {
                    //display minimum value
                    Console.WriteLine(DataCollection[0]);
                }
                else
                {
                    //Use string search method
                    search.StringSearch(DataCollection, SearchInput);
                }

                Console.WriteLine("Press any key to resort, or 'q' to quit");
                string replayChoice = Console.ReadLine();

                if (replayChoice == "Q" || replayChoice == "q")
                    replay = false;
                else
                {
                    Console.Clear();
                    replay = true;
                }

            } while (replay == true);
        }
    }

    class Sort
    {
        //string sorting algorithm
        public void QuicksortString(List<Data> data, int left, int right, int SortInput)
        {
            int i = left, j = right;

            //determine which method to use regarding how data is sorted
            switch (SortInput)
            {
                case 8:
                    IComparable pivot = data[(left + right) / 2].Region;

                    while (i <= j)
                    {
                        while (data[i].Region.CompareTo(pivot) < 0)
                        {
                            i++;
                        }

                        while (data[j].Region.CompareTo(pivot) > 0)
                        {
                            j--;
                        }

                        if (i <= j)
                        {
                            //swap values when left is larger than right
                            Data tmp = data[i];
                            data[i] = data[j];
                            data[j] = tmp;

                            i++;
                            j--;
                        }
                    }

                    //recursion
                    if (left < j)
                    {
                        //quicksort left side
                        QuicksortString(data, left, j, SortInput);
                    }

                    if (i < right)
                    {
                        //quicksort right side
                        QuicksortString(data, i, right, SortInput);
                    }
                    break;
                case 9:
                    pivot = data[(left + right) / 2].Time;

                    while (i <= j)
                    {
                        while (data[i].Time.CompareTo(pivot) < 0)
                        {
                            i++;
                        }

                        while (data[j].Time.CompareTo(pivot) > 0)
                        {
                            j--;
                        }

                        if (i <= j)
                        {
                            //swap values when left is larger than right
                            Data tmp = data[i];
                            data[i] = data[j];
                            data[j] = tmp;

                            i++;
                            j--;
                        }
                    }
                    
                    //recursion
                    if (left < j)
                    {
                        //quicksort left side
                        QuicksortString(data, left, j, SortInput);
                    }

                    if (i < right)
                    {
                        //quicksort right side
                        QuicksortString(data, i, right, SortInput);
                    }
                    break;
            }
        }

        //sort string in reverse order
        public void ReverseSort(List<Data> data, int left, int right, int SortInput)
        {
            int i = left, j = right;

            //get middle value for pivot and > and < values
            switch (SortInput)
            {
                case 8:
                    IComparable pivot = data[(left + right) / 2].Region;

                    while (i <= j)
                    {
                        while (data[i].Region.CompareTo(pivot) > 0)
                        {
                            i++;
                        }

                        while (data[j].Region.CompareTo(pivot) < 0)
                        {
                            j--;
                        }

                        if (i <= j)
                        {
                            //swap values when left is larger than right
                            Data tmp = data[i];
                            data[i] = data[j];
                            data[j] = tmp;

                            i++;
                            j--;
                        }
                    }

                    //recursion
                    if (left < j)
                    {
                        //quicksort left side
                        ReverseSort(data, left, j, SortInput);
                    }

                    if (i < right)
                    {
                        //quicksort right side
                        ReverseSort(data, i, right, SortInput);
                    }
                    break;
                case 9:
                    pivot = data[(left + right) / 2].Time;

                    while (i <= j)
                    {
                        while (data[i].Time.CompareTo(pivot) > 0)
                        {
                            i++;
                        }

                        while (data[j].Time.CompareTo(pivot) < 0)
                        {
                            j--;
                        }

                        if (i <= j)
                        {
                            //swap values when left is larger than right
                            Data tmp = data[i];
                            data[i] = data[j];
                            data[j] = tmp;

                            i++;
                            j--;
                        }
                    }

                    //recursion
                    if (left < j)
                    {
                        //quicksort left side
                        ReverseSort(data, left, j, SortInput);
                    }

                    if (i < right)
                    {
                        //quicksort right side
                        ReverseSort(data, i, right, SortInput);
                    }
                    break;
            }

            
        }

        public void QuickSortInt(int[] data, int left, int right)
        {
            int i, j;
            int pivot, temp;
            i = left;
            j = right;
            pivot = data[(i + j) / 2];

                do
                {
                    while ((data[i] < pivot) && (i < right)) i++;
                    while ((pivot < data[j]) && (j > left)) j--;
                    if (i <= j)
                    {
                        temp = data[j];
                        data[j] = data[i];
                        data[i] = temp;
                        i++;
                        j--;
                    }
                } while (i <= j);
                if (left < j) QuickSortInt(data, i, right);
                if (i < right) QuickSortInt(data, left, j);
        }

        public void InsertionSort(List<Data> data, int selectedData)
        {
            int counter = 0;
            bool GreaterThanCheck = true;

            for (int i = 0; i < data.Count - 1; i++)
            {
                int j = i + 1;

                while (j > 0)
                {
                    switch (selectedData)
                    {
                        case 1:
                            GreaterThanCheck = data[j - 1].Day > data[j].Day;
                            break;
                        case 2:
                            GreaterThanCheck = data[j - 1].Depth > data[j].Depth;
                            break;
                        case 3:
                            GreaterThanCheck = data[j - 1].IRIS_ID > data[j].IRIS_ID;
                            break;
                        case 4:
                            GreaterThanCheck = data[j - 1].Latitude > data[j].Latitude;
                            break;
                        case 5:
                            GreaterThanCheck = data[j - 1].Longitude > data[j].Longitude;
                            break;
                        case 6:
                            GreaterThanCheck = data[j - 1].Magnitude > data[j].Magnitude;
                            break;
                        case 7:
                            GreaterThanCheck = data[j - 1].MonthID > data[j].MonthID;
                            break;
                        case 10:
                            GreaterThanCheck = data[j - 1].Timestamp > data[j].Timestamp;
                            break;
                        case 11:
                            GreaterThanCheck = data[j - 1].Year > data[j].Year;
                            break;
                    }
                
                    counter++;
                    if (GreaterThanCheck)
                    {
                        Data temp = data[j - 1];
                        data[j - 1] = data[j];
                        data[j] = temp;

                    }
                    j--;
                }   
            }
            Console.WriteLine("Iterations: " + counter);
        }

        //bubble sort speed test
        public void BubbleSort(List<Data> data)
        {
            int length = data.Count;
            int counter = 0;

            Data temp = data[0];

            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    counter++;
                    if (data[i].Day > data[j].Day)
                    {
                        temp = data[i];

                        data[i] = data[j];

                        data[j] = temp;
                    }
                }
            }

            Console.WriteLine(counter);
        }

        //sort integers in reverse order
        public void ReverseInsertion (List<Data> data, int selectedData)
        {
            int counter = 0;
            bool LessThanCheck = true;

            for (int i = 0; i < data.Count - 1; i++)
            {
                int j = i + 1;

                while (j > 0)
                {
                    switch (selectedData)
                    {
                        case 1:
                            LessThanCheck = data[j - 1].Day < data[j].Day;
                            break;
                        case 2:
                            LessThanCheck = data[j - 1].Depth < data[j].Depth;
                            break;
                        case 3:
                            LessThanCheck = data[j - 1].IRIS_ID < data[j].IRIS_ID;
                            break;
                        case 4:
                            LessThanCheck = data[j - 1].Latitude < data[j].Latitude;
                            break;
                        case 5:
                            LessThanCheck = data[j - 1].Longitude < data[j].Longitude;
                            break;
                        case 6:
                            LessThanCheck = data[j - 1].Magnitude < data[j].Magnitude;
                            break;
                        case 10:
                            LessThanCheck = data[j - 1].Timestamp < data[j].Timestamp;
                            break;
                        case 11:
                            LessThanCheck = data[j - 1].Year < data[j].Year;
                            break;
                    }

                    counter++;
                    if (LessThanCheck)
                    {
                        Data temp = data[j - 1];
                        data[j - 1] = data[j];
                        data[j] = temp;

                    }
                    j--;
                }
            }
            Console.WriteLine("Iterations: " + counter);
        }

        //sorting algorithm for months
        public void SortMonths(List<Data> months, bool isReverse)
        {
            int[] monthNums = new int[months.Count];

            Dictionary<string, int> monthConvert = new Dictionary<string, int>();

            if (isReverse == true)
            {
                monthConvert.Add("January ", 12);
                monthConvert.Add("February ", 11);
                monthConvert.Add("March ", 10);
                monthConvert.Add("April ", 9);
                monthConvert.Add("May", 8);
                monthConvert.Add("June ", 7);
                monthConvert.Add("July ", 6);
                monthConvert.Add("August ", 5);
                monthConvert.Add("September ", 4);
                monthConvert.Add("October", 3);
                monthConvert.Add("November", 2);
                monthConvert.Add("December ", 1);
            }
            else
            {
                monthConvert.Add("January ", 1);
                monthConvert.Add("February ", 2);
                monthConvert.Add("March ", 3);
                monthConvert.Add("April ", 4);
                monthConvert.Add("May", 5);
                monthConvert.Add("June ", 6);
                monthConvert.Add("July ", 7);
                monthConvert.Add("August ", 8);
                monthConvert.Add("September ", 9);
                monthConvert.Add("October", 10);
                monthConvert.Add("November", 11);
                monthConvert.Add("December ", 12);
            }

            for (int i = 0; i < months.Count; i++)
            {
                int monthIndex;
                //find number related to the month
                if (monthConvert.ContainsKey(months[i].Month))
                {
                    //Retrieve month index and add number to array
                    monthConvert.TryGetValue(months[i].Month, out monthIndex);
                    months[i].MonthID = monthIndex;
                }
            }

            InsertionSort(months, 7);

        }

    }

    class Search
    {
        public void InterpolationSearch(List<Data> data, double SearchValue, int SortInput)
        {
            int index;
            int indexEq;
            int start = 0;
            int end = data.Count - 1;
            int counter = 0;

            //array containing successful results
            bool resultFound = false;

            switch (SortInput)
            {
                case 1:
                    while ((start <= end && SearchValue >= data[start].Day && SearchValue <= data[end].Day))
                    {
                        //iteration counter
                        counter++;

                        //interpolation search formula
                        index = (int)Math.Round(start + (((end - start) / (data[end].Day - data[start].Day)) * (SearchValue - data[start].Day)));
                        indexEq = index;

                        if (data[index].Day == SearchValue)
                        {
                            Console.WriteLine(data[index]);
                            resultFound = true;
                            
                            start++;
                            continue;
                        }

                        if (SearchValue > data[index].Day)
                        {
                            start = index + 1;
                        }
                        else
                        {
                            end = index - 1;
                        }
                    }
                    break;
                case 2:
                    while ((start <= end && SearchValue >= data[start].Depth && SearchValue <= data[end].Depth))
                    {
                        //iteration counter
                        counter++;

                        //interpolation search formula
                        index = (int)Math.Round(start + (((end - start) / (data[end].Depth - data[start].Depth)) * (SearchValue - data[start].Depth)));
                        indexEq = index;

                        if (data[index].Depth == SearchValue)
                        {
                            //output searched data
                            Console.WriteLine(data[index]);
                            resultFound = true;
                            start++;
                            continue;
                        }

                        if (SearchValue > data[index].Depth)
                        {
                            start = index + 1;
                        }
                        else
                        {
                            end = index - 1;
                        }
                    }
                    break;
                case 3:
                    while ((start <= end && SearchValue >= data[start].IRIS_ID && SearchValue <= data[end].IRIS_ID))
                    {
                        //iteration counter
                        counter++;

                        //interpolation search formula
                        index = (int)Math.Round(start + (((end - start) / (data[end].IRIS_ID - data[start].IRIS_ID)) * (SearchValue - data[start].IRIS_ID)));
                        indexEq = index;

                        if (data[index].IRIS_ID == SearchValue)
                        {
                            Console.WriteLine(data[index]);
                            resultFound = true;
                            start++;
                            continue;
                        }

                        if (SearchValue > data[index].IRIS_ID)
                        {
                            start = index + 1;
                        }
                        else
                        {
                            end = index - 1;
                        }
                    }
                    break;
                case 4:
                    while ((start <= end && SearchValue >= data[start].Latitude && SearchValue <= data[end].Latitude))
                    {
                        //iteration counter
                        counter++;

                        //interpolation search formula
                        index = (int)Math.Round(start + (((end - start) / (data[end].Latitude - data[start].Latitude)) * (SearchValue - data[start].Latitude)));
                        indexEq = index;

                        if (data[index].Latitude == SearchValue)
                        {
                            Console.WriteLine(data[index]);
                            resultFound = true;
                            start++;
                            continue;
                        }

                        if (SearchValue > data[index].Latitude)
                        {
                            start = index + 1;
                        }
                        else
                        {
                            end = index - 1;
                        }
                    }
                    break;
                case 5:
                    while ((start <= end && SearchValue >= data[start].Longitude && SearchValue <= data[end].Longitude))
                    {
                        //iteration counter
                        counter++;

                        //interpolation search formula
                        index = (int)Math.Round(start + (((end - start) / (data[end].Longitude - data[start].Longitude)) * (SearchValue - data[start].Longitude)));
                        indexEq = index;

                        if (data[index].Longitude == SearchValue)
                        {
                            Console.WriteLine(data[index]);
                            resultFound = true;
                            start++;
                            continue;
                        }

                        if (SearchValue > data[index].Longitude)
                        {
                            start = index + 1;
                        }
                        else
                        {
                            end = index - 1;
                        }
                    }
                    break;
                case 6:
                    while ((start <= end && SearchValue >= data[start].Magnitude && SearchValue <= data[end].Magnitude))
                    {
                        //iteration counter
                        counter++;

                        //interpolation search formula
                        index = (int)Math.Round(start + (((end - start) / (data[end].Magnitude - data[start].Magnitude)) * (SearchValue - data[start].Magnitude)));
                        indexEq = index;

                        if (data[index].Magnitude == SearchValue)
                        {
                            Console.WriteLine(data[index]);
                            resultFound = true;
                            start++;
                            continue;
                        }

                        if (SearchValue > data[index].Magnitude)
                        {
                            start = index + 1;
                        }
                        else
                        {
                            end = index - 1;
                        }
                    }
                    break;
                case 10:
                    while ((start <= end && SearchValue >= data[start].Timestamp && SearchValue <= data[end].Timestamp))
                    {
                        //iteration counter
                        counter++;

                        //interpolation search formula
                        index = (int)Math.Round(start + (((end - start) / (data[end].Timestamp - data[start].Timestamp)) * (SearchValue - data[start].Timestamp)));
                        indexEq = index;

                        if (data[index].Timestamp == SearchValue)
                        {
                            Console.WriteLine(data[index]);
                            resultFound = true;
                            start++;
                            continue;
                        }

                        if (SearchValue > data[index].Timestamp)
                        {
                            start = index + 1;
                        }
                        else
                        {
                            end = index - 1;
                        }
                    }
                    break;
                case 11:
                    while ((start <= end && SearchValue >= data[start].Year && SearchValue <= data[end].Year))
                    {
                        //iteration counter
                        counter++;

                        //interpolation search formula
                        index = (int)Math.Round(start + (((end - start) / (data[end].Year - data[start].Year)) * (SearchValue - data[start].Year)));
                        indexEq = index;

                        if (data[index].Year == SearchValue)
                        {
                            Console.WriteLine(data[index]);
                            resultFound = true;
                            start++;
                            continue;
                        }

                        if (SearchValue > data[index].Year)
                        {
                            start = index + 1;
                        }
                        else
                        {
                            end = index - 1;
                        }
                    }
                    break;
            }

            

            //display counter
            Console.WriteLine("Iterations: {0}", counter);

            //alert user of no results if array is empty
            if (resultFound == false)
            {
                Console.WriteLine("No results found for " + SearchValue);
            }
            
        }

        public void BinarySearch(List<Data> data, double SearchValue, int SortInput)
        {
            int i = 0;
            int min = 0;
            int max = data.Count - 1;
            int counter = 0;
            bool resultFound = false;
            bool LessThanCheck = true;
            bool EqualsCheck = true;

            while (min <= max && i < data.Count)
            {
                counter++;
                //half the data size and find middle point
                int mid = (min + max) / 2;

                switch (SortInput)
                {
                    case 1:
                        LessThanCheck = SearchValue < data[mid].Day;
                        EqualsCheck = SearchValue == data[mid].Day;
                        break;
                    case 2:
                        LessThanCheck = SearchValue < data[mid].Depth;
                        EqualsCheck = SearchValue == data[mid].Depth;
                        break;
                    case 3:
                        LessThanCheck = SearchValue < data[mid].IRIS_ID;
                        EqualsCheck = SearchValue == data[mid].IRIS_ID;
                        break;
                    case 4:
                        LessThanCheck = SearchValue < data[mid].Latitude;
                        EqualsCheck = SearchValue == data[mid].Latitude;
                        break;
                    case 5:
                        LessThanCheck = SearchValue < data[mid].Longitude;
                        EqualsCheck = SearchValue == data[mid].Longitude;
                        break;
                    case 6:
                        LessThanCheck = SearchValue < data[mid].Magnitude;
                        EqualsCheck = SearchValue == data[mid].Magnitude;
                        break;
                    case 10:
                        LessThanCheck = SearchValue < data[mid].Timestamp;
                        EqualsCheck = SearchValue == data[mid].Timestamp;
                        break;
                    case 11:
                        LessThanCheck = SearchValue < data[mid].Year;
                        EqualsCheck = SearchValue == data[mid].Year;
                        break;
                }

                //check if the middle value is equal to what is being searched for
                if (EqualsCheck)
                {
                    //output search results
                    Console.WriteLine(data[mid]);
                    min++;
                    resultFound = true;
                }

                //if not, check wether the value is bigger or smaller than the middle
                else if (LessThanCheck)
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }

            if (resultFound == false)
                Console.WriteLine("No Results For " + SearchValue);
            
        }

        //linear search
        public void StringSearch(List<Data> data, string SearchValue)
        {
            bool found = false;
            int i = 0;


            for (int s = 0; s < data.Count; s++)
            {
                //check if the searched string is in array
                if (data[s].Region == SearchValue || data[s].Time == SearchValue || data[s].Month == SearchValue)
                {
                    Console.WriteLine(data[s]);
                    found = true;
                    i++;
                }
            }

            //error message
            if (found == false)
            {
                Console.WriteLine("No Results found for " + SearchValue);
            }
        }

        public void LinearSearch(List<Data> data, double SearchValue)
        {
            bool found = false;
            int i = 0;

            for (int s = 0; s < data.Count; s++)
            {
                //check if the searched string is in array
                if (data[s].Day == SearchValue || data[s].Depth == SearchValue || data[s].IRIS_ID == SearchValue || data[s].Latitude == SearchValue ||
                    data[s].Longitude == SearchValue || data[s].Magnitude == SearchValue || data[s].Timestamp == SearchValue || data[s].Year == SearchValue)
                {
                    Console.WriteLine(data[s]);
                    found = true;
                    i++;
                }
            }

            if (found == false)
                Console.WriteLine("No resluts for " + SearchValue);
        }
        
    }
}
