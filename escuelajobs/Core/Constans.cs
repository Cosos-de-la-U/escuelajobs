namespace escuelajobs.Core
{
    public class Constans
    {
        public  static class Roles
        {
            public const string Administrator = "Administrator";
            public const string Docente = "Docente";
            public const string Alumno = "Alumno";
        }

        public static class Policies
        {
            public const string AdministratorRequireAdmin = "RequireAdmin";
            public const string RequireDocente = "RequireDocente";
            public const string RequireAlumno = "RequireAlumno";
        }
    }
}
