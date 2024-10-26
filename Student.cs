 public class Student
 {
    public string Name {  get; set; }
    public string StudentId { get; set; }   
    public int Age { get; set; }
    public Dictionary<string, List <int>> GradesBySubject { get; set; }

    public Student(string name, string id, int age) 
    { 
        Name = name;
        StudentId = id;
        Age = age;
        GradesBySubject = new Dictionary<string, List <int>>();
    }
 }

