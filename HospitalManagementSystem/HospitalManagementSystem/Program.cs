using System;

namespace HospitalManagementSystem
{
    class HospitalMember
    {
        protected int id;
        protected string name;
        protected int age;

        public HospitalMember(int id, string name, int age)
        {
            this.id = id;
            this.name = name;
            this.age = age;
        }
        public string GetName()
        {
            return name;
        }

        public void DisplayBasicDetails()
        {
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
        }
    }


    class Doctor : HospitalMember
    {
        private string specialization;
        private bool isAvailable;

        public Doctor(
            int id,
            string name,
            int age,
            string specialization)
            : base(id, name, age)
        {
            this.specialization = specialization;
            isAvailable = true;
        }

        public string GetSpecialization()
        {
            return specialization;
        }

        public bool GetAvailability()
        {
            return isAvailable;
        }

        public void SetAvailability(bool status)
        {
            isAvailable = status;
        }

        public void DisplayDoctorDetails()
        {
            Console.WriteLine("\n--- Doctor Details ---");

            // Inherited method from HospitalMember
            DisplayBasicDetails();

            Console.WriteLine($"Specialization: {specialization}");

            if (isAvailable)
            {
                Console.WriteLine("Status: Available");
            }
            else
            {
                Console.WriteLine("Status: Not Available");
            }
        }
    }


    class Patient : HospitalMember
    {
        private string requiredSpecialization;

        private Doctor assignedDoctor;

        private int appointmentId;

        private bool hasAppointment;

        public Patient(
            int id,
            string name,
            int age,
            string requiredSpecialization)
            : base(id, name, age)
        {
            this.requiredSpecialization = requiredSpecialization;

            assignedDoctor = null;
            appointmentId = 0;
            hasAppointment = false;
        }

        public string GetRequiredSpecialization()
        {
            return requiredSpecialization;
        }

        public void BookAppointment(
            Doctor doctor,
            int newAppointmentId)
        {
            assignedDoctor = doctor;

            appointmentId = newAppointmentId;

            hasAppointment = true;

            // Doctor is no longer available
            doctor.SetAvailability(false);

            Console.WriteLine("\nAppointment booked successfully.");
            Console.WriteLine($"Appointment ID: {appointmentId}");
            Console.WriteLine($"Patient: {name}");
            Console.WriteLine($"Doctor: {doctor.GetName()}");
            Console.WriteLine(
                $"Specialization: {doctor.GetSpecialization()}");
        }

        public void CancelAppointment()
        {
            if (!hasAppointment)
            {
                Console.WriteLine("No appointment found.");
                return;
            }

            // Doctor becomes available again
            assignedDoctor.SetAvailability(true);

            Console.WriteLine(
                $"Appointment {appointmentId} cancelled successfully.");

            appointmentId = 0;
            assignedDoctor = null;
            hasAppointment = false;
        }

        public void DisplayPatientDetails()
        {
            Console.WriteLine("\n--- Patient Details ---");

            // Inherited method from HospitalMember
            DisplayBasicDetails();

            Console.WriteLine(
                $"Required Specialization: {requiredSpecialization}");

            if (hasAppointment)
            {
                Console.WriteLine(
                    $"Appointment ID: {appointmentId}");

                Console.WriteLine(
                    $"Assigned Doctor: {assignedDoctor.GetName()}");

                Console.WriteLine(
                    $"Doctor Specialization: " +
                    $"{assignedDoctor.GetSpecialization()}");
            }
            else
            {
                Console.WriteLine("Appointment: None");
            }
        }
    }


    class Hospital
    {
        private Doctor[] doctors = new Doctor[10];

        private Patient[] patients = new Patient[10];

        private int doctorCount = 0;

        private int patientCount = 0;

        private int nextAppointmentId = 1001;


        public void AddDoctor(Doctor doctor)
        {
            if (doctorCount < doctors.Length)
            {
                doctors[doctorCount] = doctor;

                doctorCount++;

                Console.WriteLine("Doctor added successfully.");
            }
            else
            {
                Console.WriteLine("Doctor limit reached.");
            }
        }


        public void AddPatient(Patient patient)
        {
            if (patientCount < patients.Length)
            {
                patients[patientCount] = patient;

                patientCount++;

                Console.WriteLine("Patient added successfully.");
            }
            else
            {
                Console.WriteLine("Patient limit reached.");
            }
        }


        public void DisplayDoctors()
        {
            Console.WriteLine("\n===== ALL DOCTORS =====");

            if (doctorCount == 0)
            {
                Console.WriteLine("No doctors available.");
                return;
            }

            for (int i = 0; i < doctorCount; i++)
            {
                doctors[i].DisplayDoctorDetails();
            }
        }


        public void DisplayPatients()
        {
            Console.WriteLine("\n===== ALL PATIENTS =====");

            if (patientCount == 0)
            {
                Console.WriteLine("No patients available.");
                return;
            }

            for (int i = 0; i < patientCount; i++)
            {
                patients[i].DisplayPatientDetails();
            }
        }


        public void BookAppointment(string patientName)
        {
            Patient patient = null;

            // Find patient
            for (int i = 0; i < patientCount; i++)
            {
                if (patients[i].GetName() == patientName)
                {
                    patient = patients[i];

                    break;
                }
            }

            if (patient == null)
            {
                Console.WriteLine("Patient not found.");

                return;
            }


            // Find doctor based on specialization
            for (int i = 0; i < doctorCount; i++)
            {
                if (
                    doctors[i].GetSpecialization()
                    == patient.GetRequiredSpecialization()
                    &&
                    doctors[i].GetAvailability()
                   )
                {
                    patient.BookAppointment(
                        doctors[i],
                        nextAppointmentId
                    );

                    nextAppointmentId++;

                    return;
                }
            }

            Console.WriteLine(
                "No available doctor found for this specialization.");
        }


        public void CancelAppointment(string patientName)
        {
            for (int i = 0; i < patientCount; i++)
            {
                if (patients[i].GetName() == patientName)
                {
                    patients[i].CancelAppointment();

                    return;
                }
            }

            Console.WriteLine("Patient not found.");
        }
    }


    class Program
    {
        static void Main()
        {
            Hospital hospital = new Hospital();

            while (true)
            {
                Console.WriteLine(
                    "\n===== HOSPITAL MANAGEMENT SYSTEM =====");

                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. Display Doctors");
                Console.WriteLine("3. Add Patient");
                Console.WriteLine("4. Book Appointment");
                Console.WriteLine("5. Cancel Appointment");
                Console.WriteLine("6. Display Patients");
                Console.WriteLine("7. Exit");

                Console.Write("\nEnter your choice: ");

                int choice =
                    Convert.ToInt32(Console.ReadLine());


                switch (choice)
                {
                    case 1:

                        Console.Write("Enter Doctor ID: ");
                        int doctorId =
                            Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Doctor Name: ");
                        string doctorName =
                            Console.ReadLine();

                        Console.Write("Enter Doctor Age: ");
                        int doctorAge =
                            Convert.ToInt32(Console.ReadLine());

                        Console.Write(
                            "Enter Specialization: ");

                        string specialization =
                            Console.ReadLine();


                        Doctor doctor = new Doctor(
                            doctorId,
                            doctorName,
                            doctorAge,
                            specialization
                        );

                        hospital.AddDoctor(doctor);

                        break;


                    case 2:

                        hospital.DisplayDoctors();

                        break;


                    case 3:

                        Console.Write("Enter Patient ID: ");
                        int patientId =
                            Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Patient Name: ");
                        string patientName =
                            Console.ReadLine();

                        Console.Write("Enter Patient Age: ");
                        int patientAge =
                            Convert.ToInt32(Console.ReadLine());

                        Console.Write(
                            "Enter Required Specialization: ");

                        string requiredSpecialization =
                            Console.ReadLine();


                        Patient patient = new Patient(
                            patientId,
                            patientName,
                            patientAge,
                            requiredSpecialization
                        );

                        hospital.AddPatient(patient);

                        break;


                    case 4:

                        Console.Write(
                            "Enter Patient Name: ");

                        string bookingPatient =
                            Console.ReadLine();

                        hospital.BookAppointment(
                            bookingPatient);

                        break;


                    case 5:

                        Console.Write(
                            "Enter Patient Name: ");

                        string cancellingPatient =
                            Console.ReadLine();

                        hospital.CancelAppointment(
                            cancellingPatient);

                        break;


                    case 6:

                        hospital.DisplayPatients();

                        break;


                    case 7:

                        Console.WriteLine(
                            "Thank you for using the system.");

                        return;


                    default:

                        Console.WriteLine(
                            "Invalid choice.");

                        break;
                }
            }
        }
    }
}