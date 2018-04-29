namespace LMSIS.Database.DaoSqls
{
    public class ZapsanyKurzTable
    {
        private static string TABLE_NAME = "ZapsanyKurz";
        private static string SQL_INSERT = "INSERT INTO ZapsanyKurz VALUES (@DatumZapisu, @DatumUkonceni, @Splneno, " +
                                           "@IdStudent, @IdKurz)";
        private static string SQL_UPDATE = "UPDATE ZapsanyKurz SET DatumZapisu=@DatumZapisu, DatumUkonceni=" +
                                           "@DatumUkonceni, Splneno=@Splneno, IdStudent=@IdStudent, IdKurz=@IdKurz " +
                                           "WHERE IdObor=@IdObor";
        private static string SQL_DELETE_ID = "DELETE FROM ZapsanyKurz WHERE IdRegistrace=@IdRegistrace";
        private static string SQL_SELECT_ID = "SELECT IdRegistrace, DatumZapisu, DatumUkonceni, Splneno, IdStudent, " +
                                              "IdKurz FROM ZapsanyKurz WHERE IdRegistrace=@IdRegistrace";
        
    }
}