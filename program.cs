using System;
using System.Collections.Generic;

class Contact
{
    public string Name { get; set; }
    public string Phone { get; set; }
}

class ContactManager
{
    private List<Contact> contacts = new List<Contact>();

    public void AddContact(string name, string phone)
    {
        contacts.Add(new Contact { Name = name, Phone = phone });
        Console.WriteLine("Contact added successfully.\n");
    }

    public void ViewContacts()
    {
        if (contacts.Count == 0)
        {
            Console.WriteLine("No contacts available.\n");
            return;
        }

        Console.WriteLine("\n--- Contact List ---");
        foreach (var contact in contacts)
        {
            Console.WriteLine($"Name: {contact.Name}, Phone: {contact.Phone}");
        }
        Console.WriteLine();
    }

    public void SearchContact(string name)
    {
        var found = contacts.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (found != null)
            Console.WriteLine($"Found: {found.Name} - {found.Phone}\n");
        else
            Console.WriteLine("Contact not found.\n");
    }

    public void DeleteContact(string name)
    {
        var contact = contacts.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (contact != null)
        {
            contacts.Remove(contact);
            Console.WriteLine("Contact deleted.\n");
        }
        else
        {
            Console.WriteLine("Contact not found.\n");
        }
    }
}

class Program
{
    static void Main()
    {
        ContactManager manager = new ContactManager();
        int choice;

        do
        {
            Console.WriteLine("=== Contact Management System ===");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. View All Contacts");
            Console.WriteLine("3. Search Contact");
            Console.WriteLine("4. Delete Contact");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            switch (choice)
            {
                case 1:
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Phone: ");
                    string phone = Console.ReadLine();
                    manager.AddContact(name, phone);
                    break;
                case 2:
                    manager.ViewContacts();
                    break;
                case 3:
                    Console.Write("Enter name to search: ");
                    string searchName = Console.ReadLine();
                    manager.SearchContact(searchName);
                    break;
                case 4:
                    Console.Write("Enter name to delete: ");
                    string deleteName = Console.ReadLine();
                    manager.DeleteContact(deleteName);
                    break;
                case 5:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice.\n");
                    break;
            }

        } while (choice != 5);
    }
}
