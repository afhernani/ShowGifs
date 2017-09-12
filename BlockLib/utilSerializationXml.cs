/*
 * Creado por SharpDevelop.
 * Usuario: hernani
 * Fecha: 18/05/2017
 * Hora: 3:08
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Reflection;
using Newtonsoft.Json;

namespace BlockLib
{
	/// <summary>
	/// Description of utilSerializationXml.
	/// </summary>
	public class UtilSerializationXml
	{
		public UtilSerializationXml()
		{
		}
		/// <summary>
		/// Una vez obtenido como cadena, lo puedes guardar a un archivo vía
		///	System.IO.File.WriteAllLines(ruta, cadenaXml);
		/// </summary>
		/// <param name="item"></param>
		/// <param name="removeNamespace"></param>
		/// <returns></returns>
		public static string Serialize(object item, bool removeNamespace = true)
		{
			if (item == null)
				return null;
			var stringBuilder = new StringBuilder();
			var itemType = item.GetType();
			//remueve "lo.que.sea.el.namespace.de.tu" del nombre completo de la clase: lo.que.sea.el.namespace.de.tu.ClaseConDatos
			if (removeNamespace) {
				var xns = new XmlSerializerNamespaces();
				xns.Add(String.Empty, String.Empty);
				new XmlSerializer(itemType).Serialize(new StringWriter(stringBuilder), item, xns);
			} else {
				new XmlSerializer(itemType).Serialize(new StringWriter(stringBuilder), item);
			}
			return stringBuilder.ToString();
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="xmlInput"></param>
		/// <param name="extraTypes"></param>
		/// <returns></returns>
		public static T getObjectOfXml<T>(string xmlInput, Type[] extraTypes)
		{
			
			object obj = null;
			
			XmlSerializer s = new XmlSerializer(typeof(T), extraTypes);
			using (TextReader r = new StreamReader(xmlInput)) {
				try {
					obj = s.Deserialize(r);
					return (T)obj;
				} catch (Exception ex) {
					Debug.WriteLine(ex.Message);
					return default(T);
				}
			}
			
		}
		/// <summary>
		/// Serialización objeto generico json,
		/// retorna una cadena serializada lista para guardar a fichero.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static string SerializeJson(object obj)
		{
			string json = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
			return json;
		}
		/// <summary>
		/// devuelve un objeto tipo generico,
		/// entrada fichero serializado del objeto.
		/// </summary>
		/// <param name="jsonInput"></param>
		/// <returns></returns>
		public static T getObjectOffJson<T>(string jsonInput)
		{
			//deberiamos comprobar que existe fichero ??
			string cadjson = File.ReadAllText(jsonInput);
			T obj = JsonConvert.DeserializeObject<T>(cadjson);
			return obj;
		}

	}
}
