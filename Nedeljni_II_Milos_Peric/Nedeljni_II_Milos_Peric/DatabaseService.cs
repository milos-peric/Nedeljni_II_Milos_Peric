using Nedeljni_II_Milos_Peric.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni_II_Milos_Peric
{
    class DatabaseService
    {
        internal vwClinicAdmin AddClinicAdministrator(vwClinicAdmin admin)
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    tblUser newUser = new tblUser();
                    newUser.FullName = admin.FullName;
                    newUser.IDCardNumber = admin.IDCardNumber;
                    newUser.Gender = admin.Gender;
                    newUser.DateOfBirth = admin.DateOfBirth;
                    newUser.Nationality = admin.Nationality;
                    newUser.Username = admin.Username;
                    newUser.Password = admin.Password;
                    context.tblUsers.Add(newUser);
                    context.SaveChanges();
                    admin.UserID = newUser.UserID;
                    tblClinicAdmin newAdmin = new tblClinicAdmin();
                    newAdmin.HasCreatedClinic = admin.HasCreatedClinic;
                    newAdmin.UserID = admin.UserID;
                    context.tblClinicAdmins.Add(newAdmin);
                    context.SaveChanges();
                    admin.AdminID = newAdmin.AdminID;
                    return admin;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        internal tblClinicInstitution AddClinic(tblClinicInstitution clinic)
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    tblClinicInstitution newClinic = new tblClinicInstitution();
                    newClinic.InstitutionName = clinic.InstitutionName;
                    newClinic.CreationDate = clinic.CreationDate;
                    newClinic.InstitutionOwner = clinic.InstitutionOwner;
                    newClinic.InstitutionAddress = clinic.InstitutionAddress;
                    newClinic.NumberOdFloors = clinic.NumberOdFloors;
                    newClinic.NumberOfRoomsPerFloor = clinic.NumberOfRoomsPerFloor;
                    newClinic.HasTerrace = clinic.HasTerrace;
                    newClinic.HasYard = clinic.HasYard;
                    newClinic.NumberOfAccessPointsForAmbulance = clinic.NumberOfAccessPointsForAmbulance;
                    newClinic.NumberOfAccessPointsForInvalids = clinic.NumberOfAccessPointsForInvalids;
                    context.tblClinicInstitutions.Add(newClinic);
                    context.SaveChanges();
                    clinic.InstitutionID = newClinic.InstitutionID;
                    return clinic;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        internal void ChangeHasCreatedClinicProperty(vwClinicAdmin admin)
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    vwClinicAdmin adminToFind = (from a in context.vwClinicAdmins where a.UserID == admin.UserID select a).First();
                    adminToFind.HasCreatedClinic = admin.HasCreatedClinic;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Clinic Admin not found!" + ex.Message.ToString());
            }
        }

        internal vwClinicAdmin FindClinicAdminCredentials(string userName, string password)
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    string encryptedPassword = EncryptionHelper.Encrypt(password);
                    vwClinicAdmin adminToFind = (from a in context.vwClinicAdmins where a.Username == userName && a.Password == encryptedPassword select a).First();
                    return adminToFind;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Clinic Admin not found!" + ex.Message.ToString());
                return null;
            }
        }
    }
}
