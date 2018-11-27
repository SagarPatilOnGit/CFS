using System;
using System.Collections.Generic;

namespace CFSClient.GoF.Creational
{
	public abstract class Document
	{
		private List<Page> _pages = new List<Page>();

		public Document()
		{
			GetDocument();
		}

		public List<Page> Pages { get { return _pages; } }

		public abstract void GetDocument();
	}

	public abstract class Page
	{
	}

	class SkillsPage : Page
	{
	}
		
	class EducationPage : Page
	{
	}

	class ExperiencePage : Page
	{
	}

	public class Resume : Document
	{
		public override void GetDocument()
		{
			Pages.Add(new EducationPage());
			Pages.Add(new SkillsPage());
			Pages.Add(new ExperiencePage());
		}
	}

	//Consumer client of Factory method design pattern
	public class FactoryMethodClient
	{
		public void GetDocuments()
		{
			// Note: constructors call Factory Method
			var documents = new Document[1] { new Resume() };
			// Display document pages
			foreach (Document document in documents)
			{
				Console.WriteLine("\n" + document.GetType().Name + "--");
				foreach (Page page in document.Pages)
				{
					Console.WriteLine(" " + page.GetType().Name);
				}
			}
		}
	}
}
