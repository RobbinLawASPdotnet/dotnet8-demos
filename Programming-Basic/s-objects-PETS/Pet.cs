using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsRLaw
{
	public class Pet
	{
		// Private Fields.
		private const double ACEPROMAZINEFORCAT = 0.002;
		private const double ACEPROMAZINEFORDOG = 0.03;
		private const double CARPROFENFORCAT = 0.25;
		private const double CARPROFENFORDOG = 0.5;
		private string _tag;
		private string _name;
		private double _age;
		private double _weight;
		private string _type;

		// Non-Greedy Constructor.
		public Pet()
		{
			Tag="XXXX";
			Name="YYYY";
			Age = 0;
			Weight = 0;
			Type = "CAT";
		}

		// Greedy Constructor.
		public Pet(string tag, string name, double age, double weight, string petType)
		{
			Tag=tag;
			Name=name;
			Age = age;
			Weight = weight;
			Type = petType;
		}

		// Fully Implemented Properties
		public string Tag
		{
			get { return _tag; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("Tag is required. Must not be empty or blank.");
				_tag = value;
			}
		}

		public string Name
		{
			get { return _name; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("Name is required. Must not be empty or blank.");
				_name = value;
			}
		}

		public double Age
		{
			get { return _age; }
			set
			{
				if (value < 0.0)
					throw new ArgumentException("Age must be a positive value (0 or greater)");
				_age = value;
			}
		}

		public double Weight
		{
			get { return _weight; }
			set
			{
				if (value < 0.0)
					throw new ArgumentException("Weight must be a positive value (0 or greater)");
				_weight = value;
			}
		}

		public string Type
		{
			get { return _type; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("Type is required. Must not be empty or blank.");
				if (!(value.ToUpper().Equals("CAT") || value.ToUpper().Equals("DOG")))
					throw new ArgumentException("Type must be Cat or Dog.");
				_type = value;
			}
		}
   
	 	// Read Only Fully Implemented Properties
		public double Acepromazine
		{
			get
			{
				double dosage = 0.0;
				if (Type.ToUpper().Equals("CAT"))
					dosage = Weight *(ACEPROMAZINEFORCAT / 10.0);
				else
					dosage = Weight *(ACEPROMAZINEFORDOG / 10.0);
				return dosage;
			}
		}

		public double Carprofen
		{
			get
			{
				double dosage = 0.0;
				if (Type.ToUpper().Equals("CAT"))
					dosage = Weight *(CARPROFENFORCAT / 12.0);
				else
					dosage = Weight *(CARPROFENFORDOG / 12.0);
				return dosage;
			}
		}

		// method
		public override string ToString()
		{
			return $"{Tag},{Name},{Age},{Weight},{Type}";
		}
	}
}
