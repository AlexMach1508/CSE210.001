using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Icon Solutions";
        job1._startYear = 2025;
        job1._endYear = 2024;

        Job job2 = new Job();
        job2._jobTitle = "Supervisor";
        job2._company = "VXI";
        job2._startYear = 2024;
        job2._endYear = 2020;

        Resume myResume = new Resume();
        myResume._name = "Alex Castillo";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }

}