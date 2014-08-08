namespace DocumentSystem
{
    using System;
    using System.Collections.Generic;

    public class DocumentSystem
    {
        private static IList<IDocument> documents = new List<IDocument>();

        public static void Main()
        {
            IList<string> allCommands = ReadAllCommands();
            ExecuteCommands(allCommands);
        }

        private static IList<string> ReadAllCommands()
        {
            List<string> commands = new List<string>();
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "")
                {
                    // End of commands
                    break;
                }
                commands.Add(commandLine);
            }
            return commands;
        }

        private static void ExecuteCommands(IList<string> commands)
        {
            foreach (var commandLine in commands)
            {
                int paramsStartIndex = commandLine.IndexOf("[");
                string cmd = commandLine.Substring(0, paramsStartIndex);
                int paramsEndIndex = commandLine.IndexOf("]");
                string parameters = commandLine.Substring(
                    paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
                ExecuteCommand(cmd, parameters);
            }
        }

        private static void ExecuteCommand(string cmd, string parameters)
        {
            string[] cmdAttributes = parameters.Split(
                new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (cmd == "AddTextDocument")
            {
                AddTextDocument(cmdAttributes);
            }
            else if (cmd == "AddPDFDocument")
            {
                AddPdfDocument(cmdAttributes);
            }
            else if (cmd == "AddWordDocument")
            {
                AddWordDocument(cmdAttributes);
            }
            else if (cmd == "AddExcelDocument")
            {
                AddExcelDocument(cmdAttributes);
            }
            else if (cmd == "AddAudioDocument")
            {
                AddAudioDocument(cmdAttributes);
            }
            else if (cmd == "AddVideoDocument")
            {
                AddVideoDocument(cmdAttributes);
            }
            else if (cmd == "ListDocuments")
            {
                ListDocuments();
            }
            else if (cmd == "EncryptDocument")
            {
                EncryptDocument(parameters);
            }
            else if (cmd == "DecryptDocument")
            {
                DecryptDocument(parameters);
            }
            else if (cmd == "EncryptAllDocuments")
            {
                EncryptAllDocuments();
            }
            else if (cmd == "ChangeContent")
            {
                ChangeContent(cmdAttributes[0], cmdAttributes[1]);
            }
            else
            {
                throw new InvalidOperationException("Invalid command: " + cmd);
            }
        }

        private static void AddTextDocument(string[] attributes)
        {
            AddDocument(new TextDocument(), attributes);
        }

        private static void AddPdfDocument(string[] attributes)
        {
            AddDocument(new PDFDocument(), attributes);
        }

        private static void AddWordDocument(string[] attributes)
        {
            AddDocument(new WordDocument(), attributes);
        }

        private static void AddExcelDocument(string[] attributes)
        {
            AddDocument(new ExcelDocument(), attributes);
        }

        private static void AddAudioDocument(string[] attributes)
        {
            AddDocument(new AudioDocument(), attributes);
        }

        private static void AddVideoDocument(string[] attributes)
        {
            AddDocument(new VideoDocument(), attributes);
        }

        private static void ListDocuments()
        {
            if (documents.Count > 0)
            {
                foreach (var currentDocument in documents)
                {
                    Console.WriteLine(currentDocument);
                }
            }
            else
            {
                Console.WriteLine("No documents found");
            }
        }

        private static void EncryptDocument(string name)
        {
            bool result = false;

            foreach (var currentDocument in documents)
            {
                if (currentDocument.Name.Equals(name))
                {
                    if (currentDocument is IEncryptable)
                    {
                        ((IEncryptable)currentDocument).Encrypt();

                        Console.WriteLine("Document encrypted: {0}", name);
                    }
                    else
                    {
                        Console.WriteLine("Document does not support encryption: {0}", name);
                    }

                    result = true;
                }
            }

            if (!result)
            {
                Console.WriteLine("Document not found: {0}", name);
            }
        }

        private static void DecryptDocument(string name)
        {
            bool result = false;

            foreach (var currentDocument in documents)
            {
                if (currentDocument.Name.Equals(name))
                {
                    if (currentDocument is IEncryptable)
                    {
                        ((IEncryptable)currentDocument).Decrypt();

                        Console.WriteLine("Document decrypted: {0}", name);
                    }
                    else
                    {
                        Console.WriteLine("Document does not support decryption: {0}", name);
                    }

                    result = true;
                }
            }

            if (!result)
            {
                Console.WriteLine("Document not found: {0}", name);
            }
        }

        private static void EncryptAllDocuments()
        {
            bool result = false;

            foreach (var currentDocument in documents)
            {
                if (currentDocument is IEncryptable)
                {
                    ((IEncryptable)currentDocument).Encrypt();

                    result = true;
                }
            }

            if (!result)
            {
                Console.WriteLine("No encryptable documents found");
            }
            else
            {
                Console.WriteLine("All documents encrypted");
            }
        }

        private static void ChangeContent(string name, string content)
        {
            bool result = false;

            foreach (var currentDocument in documents)
            {
                if (currentDocument.Name.Equals(name))
                {
                    if (currentDocument is IEditable)
                    {
                        ((IEditable)currentDocument).ChangeContent(content);

                        Console.WriteLine("Document content changed: {0}", name);
                    }
                    else
                    {
                        Console.WriteLine("Document is not editable: {0}", name);
                    }

                    result = true;
                }
            }

            if (!result)
            {
                Console.WriteLine("Document not found: {0}", name);
            }
        }

        private static void AddDocument(IDocument document, string[] attributes)
        {
            foreach (var currentAttribute in attributes)
            {
                string[] keyAndValue = currentAttribute.Split('=');
                string key = keyAndValue[0];
                string value = keyAndValue[1];

                document.LoadProperty(key, value);
            }
            if (document.Name != null)
            {
                documents.Add(document);

                Console.WriteLine("Document added: " + document.Name);
            }
            else
            {
                Console.WriteLine("Document has no name");
            }
        }
    }
}