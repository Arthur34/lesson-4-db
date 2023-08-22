// See https://aka.ms/new-console-template for more information
using MyConsoleApp;
using MyConsoleApp.Entities;
using MyConsoleApp.DB;
using MyConsoleApp.Repositories;

var _dbcontext = new DatabaseContext();

// Вывести все таблицы
void ShowAllTables()
{
    Console.Clear();
    Console.WriteLine("SHOW ALL TABLES\n");

    Console.WriteLine("\nCOURSES:");
    foreach (var c in new CourseRepo(_dbcontext).GetAll())
    {
        Console.WriteLine($"Id: {c.Id}, Name: {c.Name}");
    }

    Console.WriteLine("\nTOPICS:");
    foreach (var t in new TopicRepo(_dbcontext).GetAll())
    {
        Console.WriteLine($"Id: {t.Id}, CourseId: {t.CourseId}, Name: {t.Name}");
    }

    Console.WriteLine("\nLEARNERS:");
    foreach (var l in new LearnerRepo(_dbcontext).GetAll())
    {
        Console.WriteLine($"Id: {l.Id}, Name: {l.Name}");
    }

    Console.WriteLine("\nLEARNERS_COURSES:");
    foreach (var lc in new LearnerCourseRepo(_dbcontext).GetAll())
    {
        Console.WriteLine($"Id: {lc.Id}, Learner: {lc.Learner.Name}, Course: {lc.Course.Name}");
    }

    Console.WriteLine("\nLEARNERSCOURSERS_TOPICS: ");
    foreach (var lct in new LearnerCourseTopicRepo(_dbcontext).GetAll())
    {
        Console.Write($"Id: {lct.Id}, Learner: {lct.LearnerCourse.Learner.Name}, ");
        Console.Write($"Course: {lct.LearnerCourse.Course.Name}, Topic: {lct.Topic.Name}, Points: ");
        Console.WriteLine((lct.Points != null) ? lct.Points.ToString() : "-");
    }

    Console.Write("\nPress any key to continue... ");
    Console.ReadKey();
}

// Добавить курс
void AddCourse()
{
    var repo = new CourseRepo(_dbcontext);
    var course = new Course();

    Console.Clear();
    Console.WriteLine("ADD COURSE\n");

    Console.Write("Course name: ");
    course.Name = Console.ReadLine();

    repo.Add(course);
    repo.SaveChanges();
}

// Добавить тему курса
void AddTopic()
{
    var repo = new TopicRepo(_dbcontext);
    var topic = new Topic();

    Console.Clear();
    Console.WriteLine("ADD TOPIC\n");

    //TODO: Добавить обработчики на некорректный ввод
    Console.Write("Course Id: ");
    topic.CourseId = int.Parse(Console.ReadLine());
    Console.Write("Topic name: ");
    topic.Name = Console.ReadLine();

    repo.Add(topic);
    repo.SaveChanges();
}

// Добавить учащегося
void AddLearner()
{
    var repo = new LearnerRepo(_dbcontext);
    var learner = new Learner();

    Console.Clear();
    Console.WriteLine("ADD LEARNER\n");

    //TODO: Добавить обработчики на некорректный ввод
    Console.Write("Learner name: ");
    learner.Name = Console.ReadLine();

    repo.Add(learner);
    repo.SaveChanges();
}

// Добавить учащегося к курсу
void AddLearnerToCourse()
{
    var repo = new LearnerCourseRepo(_dbcontext);
    var entity = new LearnerCourse();

    Console.Clear();
    Console.WriteLine("ADD LEARNER TO COURSE\n");

    //TODO: Добавить обработчики на некорректный ввод
    Console.Write("Course Id: ");
    entity.CourseId = int.Parse(Console.ReadLine());
    Console.Write("Learner Id: ");
    entity.LearnerId = int.Parse(Console.ReadLine());

    repo.Add(entity);
    repo.SaveChanges();
}

// Добавить баллы за прошедшую тему для учащегося
void AddTopicToLearnerCourse()
{
    var repo = new LearnerCourseTopicRepo(_dbcontext);
    var entity = new LearnerCourseTopic();

    Console.Clear();
    Console.WriteLine("ADD LAST TOPIC TO LEARNER COURSE\n");

    //TODO: Добавить обработчики на некорректный ввод
    Console.Write("Learner course Id: ");
    entity.LearnerCourseId = int.Parse(Console.ReadLine());
    Console.Write("Topic Id: ");
    entity.TopicId = int.Parse(Console.ReadLine());
    Console.Write("Points: ");
    entity.Points = short.Parse(Console.ReadLine());

    repo.Add(entity);
    repo.SaveChanges();
}

var k = new ConsoleKeyInfo();

do
{
    Console.Clear();
    Console.WriteLine("MENU:\n");

    Console.WriteLine("1: Show all tables");
    Console.WriteLine("2: Add course");
    Console.WriteLine("3: Add topic");
    Console.WriteLine("4: Add learner");
    Console.WriteLine("5: Add learner to course");
    Console.WriteLine("6: Add last topic to learner course");
    Console.WriteLine("\nX: Exit");

    Console.WriteLine();
    Console.Write("Press key to continue: ");
    k = Console.ReadKey();

    switch (k.Key)
    {
        case ConsoleKey.D1:
            ShowAllTables();
            break;

        case ConsoleKey.D2:
            AddCourse();
            break;

        case ConsoleKey.D3:
            AddTopic();
            break;

        case ConsoleKey.D4:
            AddLearner();
            break;

        case ConsoleKey.D5:
            AddLearnerToCourse();
            break;

        case ConsoleKey.D6:
            AddTopicToLearnerCourse();
            break;

        case ConsoleKey.X:
            break;
    }

} while (k.Key != ConsoleKey.X);
