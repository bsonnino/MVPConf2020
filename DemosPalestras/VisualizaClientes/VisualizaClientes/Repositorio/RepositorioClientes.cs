using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using VisualizaClientes.Model;

namespace VisualizaClientes.Repositorio
{
    public class RepositorioClientes : IRepositorioClientes
    {
        private readonly IList<Cliente> clientes;

        public RepositorioClientes()
        {
            var doc = XDocument.Load("Clientes.xml");
            clientes = new ObservableCollection<Cliente>((from c in doc.Descendants("Cliente")
                         select new Cliente
                                    {
                                        CustomerId = GetValueOrDefault(c, "CustomerId"),
                                        CompanyName = GetValueOrDefault(c, "CompanyName"),
                                        ContactName = GetValueOrDefault(c, "ContactName"),
                                        ContactTitle = GetValueOrDefault(c, "ContactTitle"),
                                        Address = GetValueOrDefault(c, "Address"),
                                        City = GetValueOrDefault(c, "City"),
                                        Region = GetValueOrDefault(c, "Region"),
                                        PostalCode = GetValueOrDefault(c, "PostalCode"),
                                        Country = GetValueOrDefault(c, "Country"),
                                        Phone = GetValueOrDefault(c, "Phone"),
                                        Fax = GetValueOrDefault(c, "Fax")
                                    }).ToList());
        }

        #region IRepositorioClientes Members

        public bool Add(Cliente cliente)
        {
            if (clientes.IndexOf(cliente) < 0)
            {
                clientes.Add(cliente);
                return true;
            }
            return false;
        }

        public bool Remove(Cliente cliente)
        {
            if (clientes.IndexOf(cliente) >= 0)
            {
                clientes.Remove(cliente);
                return true;
            }
            return false;
        }

        public bool Commit()
        {
            try
            {
                var doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
                var root = new XElement("Clientes");
                foreach (Cliente customer in clientes)
                {
                    root.Add(new XElement("Cliente",
                                          new XElement("CustomerID", customer.CustomerId),
                                          new XElement("CompanyName", customer.CompanyName),
                                          new XElement("ContactName", customer.ContactName),
                                          new XElement("ContactTitle", customer.ContactTitle),
                                          new XElement("Address", customer.Address),
                                          new XElement("City", customer.City),
                                          new XElement("Region", customer.Region),
                                          new XElement("PostalCode", customer.PostalCode),
                                          new XElement("Country", customer.Country),
                                          new XElement("Phone", customer.Phone),
                                          new XElement("Fax", customer.Fax)
                                 ));
                }
                doc.Add(root);
                doc.Save("Clientes.xml");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Cliente> Clientes
        {
            get { return clientes; }
        }

        #endregion

        private static string GetValueOrDefault(XContainer el, string propertyName)
        {
            return el.Element(propertyName) == null ? string.Empty : el.Element(propertyName).Value;
        }
    }
}