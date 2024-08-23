using System;
using Development.Services;
using Development.Models;

class Program
{
    static void Main(string[] args)
    {
        var schoolService = new SchoolService();
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Cadastrar Turma");
            Console.WriteLine("2. Cadastrar Estudante");
            Console.WriteLine("3. Cadastrar Professor");
            Console.WriteLine("4. Cadastrar Matéria");
            Console.WriteLine("5. Atribuir Professor a uma Matéria e Turma");
            Console.WriteLine("6. Atribuir Nota a Estudante");
            Console.WriteLine("7. Ver Boletim do Estudante");
            Console.WriteLine("8. Visualizar Lista");
            Console.WriteLine("0. Sair");
            Console.Write("Opção: ");

            var option = Console.ReadLine()?.Trim();

            switch (option)
            {
                case "1":
                    RegisterGroup(schoolService);
                    break;
                case "2":
                    RegisterStudent(schoolService);
                    break;
                case "3":
                    RegisterTeacher(schoolService);
                    break;
                case "4":
                    RegisterSubject(schoolService);
                    break;
                case "5":
                    AssignTeacherToSubject(schoolService);
                    break;
                case "6":
                    AddStudentMark(schoolService);
                    break;
                case "7":
                    ViewStudentReportCard(schoolService);
                    break;
                case "8":
                    ViewList(schoolService);
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

            if (!exit)
            {
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    static void RegisterGroup(SchoolService schoolService)
    {
        Console.Write("Nome da Turma: ");
        string? groupName = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(groupName))
        {
            Console.WriteLine("O nome da Turma não pode ser vazio.");
            return;
        }

        schoolService.AddGroup(groupName);
        Console.WriteLine("Turma cadastrada com sucesso!");
    }

    static void RegisterStudent(SchoolService schoolService)
    {
        if (schoolService.Groups.Count == 0)
        {
            Console.WriteLine("Nenhuma turma cadastrada. Cadastre uma turma primeiro.");
            return;
        }

        Console.Write("Nome do Estudante: ");
        string? firstName = Console.ReadLine()?.Trim();
        Console.Write("Sobrenome do Estudante: ");
        string? lastName = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
        {
            Console.WriteLine("Nome e Sobrenome são obrigatórios.");
            return;
        }

        // Mostrar lista de Turmas
        Console.WriteLine("Turmas disponíveis:");
        foreach (var group in schoolService.Groups)
        {
            Console.WriteLine($"ID: {group.GroupId}, Nome: {group.Name}");
        }

        Console.Write("ID da Turma: ");
        string? groupIdStr = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(groupIdStr) || !int.TryParse(groupIdStr, out int groupId))
        {
            Console.WriteLine("ID de Turma inválido.");
            return;
        }

        schoolService.AddStudent(firstName, lastName, groupId);
        Console.WriteLine("Estudante cadastrado com sucesso!");
    }

    static void RegisterTeacher(SchoolService schoolService)
    {
        Console.Write("Nome do Professor: ");
        string? firstName = Console.ReadLine()?.Trim();
        Console.Write("Sobrenome do Professor: ");
        string? lastName = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
        {
            Console.WriteLine("Nome e Sobrenome são obrigatórios.");
            return;
        }

        schoolService.AddTeacher(firstName, lastName);
        Console.WriteLine("Professor cadastrado com sucesso!");
    }

    static void RegisterSubject(SchoolService schoolService)
    {
        Console.Write("Título da Matéria: ");
        string? title = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(title))
        {
            Console.WriteLine("O título da matéria não pode ser vazio.");
            return;
        }

        schoolService.AddSubject(title);
        Console.WriteLine("Matéria cadastrada com sucesso!");
    }

    static void AssignTeacherToSubject(SchoolService schoolService)
    {
        if (schoolService.Teachers.Count == 0 || schoolService.Subjects.Count == 0 || schoolService.Groups.Count == 0)
        {
            Console.WriteLine("Certifique-se de que professores, matérias e turmas estejam cadastrados.");
            return;
        }

        // Mostrar lista de professores
        Console.WriteLine("Professores disponíveis:");
        foreach (var teacher in schoolService.Teachers)
        {
            Console.WriteLine($"ID: {teacher.TeacherId}, Nome: {teacher.FirstName} {teacher.LastName}");
        }

        Console.Write("ID do Professor: ");
        string? teacherIdStr = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(teacherIdStr) || !int.TryParse(teacherIdStr, out int teacherId))
        {
            Console.WriteLine("ID de Professor inválido.");
            return;
        }

        // Mostrar lista de matérias
        Console.WriteLine("Matérias disponíveis:");
        foreach (var subject in schoolService.Subjects)
        {
            Console.WriteLine($"ID: {subject.SubjectId}, Título: {subject.Title}");
        }

        Console.Write("ID da Matéria: ");
        string? subjectIdStr = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(subjectIdStr) || !int.TryParse(subjectIdStr, out int subjectId))
        {
            Console.WriteLine("ID de Matéria inválido.");
            return;
        }

        // Mostrar lista de Turmas
        Console.WriteLine("Turmas disponíveis:");
        foreach (var group in schoolService.Groups)
        {
            Console.WriteLine($"ID: {group.GroupId}, Nome: {group.Name}");
        }

        Console.Write("ID da Turma: ");
        string? groupIdStr = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(groupIdStr) || !int.TryParse(groupIdStr, out int groupId))
        {
            Console.WriteLine("ID de Turma inválido.");
            return;
        }

        schoolService.AssignTeacherToSubject(teacherId, subjectId, groupId);
        Console.WriteLine("Professor atribuído à matéria e turma com sucesso!");
    }

    static void AddStudentMark(SchoolService schoolService)
    {
        if (schoolService.Students.Count == 0 || schoolService.Subjects.Count == 0)
        {
            Console.WriteLine("Certifique-se de que estudantes e matérias estejam cadastrados.");
            return;
        }

        // Mostrar lista de estudantes
        Console.WriteLine("Estudantes disponíveis:");
        foreach (var student in schoolService.Students)
        {
            Console.WriteLine($"ID: {student.StudentId}, Nome: {student.FirstName} {student.LastName}");
        }

        Console.Write("ID do Estudante: ");
        string? studentIdStr = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(studentIdStr) || !int.TryParse(studentIdStr, out int studentId))
        {
            Console.WriteLine("ID de Estudante inválido.");
            return;
        }

        // Mostrar lista de matérias
        Console.WriteLine("Matérias disponíveis:");
        foreach (var subject in schoolService.Subjects)
        {
            Console.WriteLine($"ID: {subject.SubjectId}, Título: {subject.Title}");
        }

        Console.Write("ID da Matéria: ");
        string? subjectIdStr = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(subjectIdStr) || !int.TryParse(subjectIdStr, out int subjectId))
        {
            Console.WriteLine("ID de Matéria inválido.");
            return;
        }

        Console.Write("Nota: ");
        string? gradeStr = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(gradeStr) || !int.TryParse(gradeStr, out int grade) || grade < 0 || grade > 100)
        {
            Console.WriteLine("Nota inválida. Deve ser um número entre 0 e 100.");
            return;
        }

        schoolService.AddMark(studentId, subjectId, grade);
        Console.WriteLine("Nota atribuída com sucesso!");
    }

    static void ViewStudentReportCard(SchoolService schoolService)
    {
        if (schoolService.Students.Count == 0)
        {
            Console.WriteLine("Nenhum estudante cadastrado.");
            return;
        }

        // Mostrar lista de estudantes
        Console.WriteLine("Estudantes disponíveis:");
        foreach (var student in schoolService.Students)
        {
            Console.WriteLine($"ID: {student.StudentId}, Nome: {student.FirstName} {student.LastName}");
        }

        Console.Write("ID do Estudante: ");
        string? studentIdStr = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(studentIdStr) || !int.TryParse(studentIdStr, out int studentId))
        {
            Console.WriteLine("ID de Estudante inválido.");
            return;
        }

        schoolService.PrintStudentReportCard(studentId);
    }

    static void ViewList(SchoolService schoolService)
    {
        Console.WriteLine("Escolha o tipo de lista para visualizar:");
        Console.WriteLine("1. Estudantes");
        Console.WriteLine("2. Turmas");
        Console.WriteLine("3. Professores");
        Console.WriteLine("4. Matérias");
        Console.Write("Opção: ");

        var option = Console.ReadLine()?.Trim();

        switch (option)
        {
            case "1":
                Console.WriteLine("Estudantes:");
                foreach (var student in schoolService.Students)
                {
                    Console.WriteLine($"ID: {student.StudentId}, Nome: {student.FirstName} {student.LastName}");
                }
                break;
            case "2":
                Console.WriteLine("Turmas:");
                foreach (var group in schoolService.Groups)
                {
                    Console.WriteLine($"ID: {group.GroupId}, Nome: {group.Name}");
                }
                break;
            case "3":
                Console.WriteLine("Professores:");
                foreach (var teacher in schoolService.Teachers)
                {
                    Console.WriteLine($"ID: {teacher.TeacherId}, Nome: {teacher.FirstName} {teacher.LastName}");
                }
                break;
            case "4":
                Console.WriteLine("Matérias:");
                foreach (var subject in schoolService.Subjects)
                {
                    Console.WriteLine($"ID: {subject.SubjectId}, Título: {subject.Title}");
                }
                break;
            default:
                Console.WriteLine("Opção inválida!");
                break;
        }
    }
}
