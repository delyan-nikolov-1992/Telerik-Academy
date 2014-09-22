/*
 * 05. Write a program that retrieves the images for all categories in the Northwind database 
 * and stores them as JPG files in the file system.
*/
namespace AllImages
{
    using System;
    using System.Data.SqlClient;
    using System.IO;

    public class AllImages
    {
        private const string SqlConnectionString = "Server=.; Database=Northwind; Integrated Security=true";
        private const int PictureHeader = 78;

        public static void Main()
        {
            SqlConnection dbCon = new SqlConnection(SqlConnectionString);
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand cmdAllPictures = new SqlCommand(
                    "SELECT CategoryID, Picture FROM Categories;", dbCon);

                SqlDataReader reader = cmdAllPictures.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        int categoryID = (int)reader["CategoryID"];
                        byte[] picture = (byte[])reader["Picture"];

                        // the first 78 bytes are ignored, because this is the header of the image
                        byte[] pictureWithoutHeader = new byte[picture.Length - PictureHeader];

                        for (int i = 0; i < pictureWithoutHeader.Length; i++)
                        {
                            pictureWithoutHeader[i] = picture[i + PictureHeader];
                        }

                        File.WriteAllBytes(@"..\..\Images\" + categoryID.ToString() + ".jpg", pictureWithoutHeader);
                    }
                }
            }
        }
    }
}