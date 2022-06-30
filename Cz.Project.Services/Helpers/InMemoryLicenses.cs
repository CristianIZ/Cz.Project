using Cz.Project.Abstraction;
using Cz.Project.Domain;
using Cz.Project.Dto;
using Cz.Project.SQLContext.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cz.Project.Services.Helpers
{
    public class InMemoryLicenses
    {
        public IList<License> licenses { get; set; }
        public IList<LicenseCodeRelation> licenseCodeRelations { get; set; }

        /// <summary>
        /// Populate the lists from database
        /// </summary>
        public InMemoryLicenses()
        {
            var licenseService = new LicenseService();

            this.licenses = new LicensesContext().GetAll();
            this.licenseCodeRelations = licenseService.MapToCodeRelation(this.licenses, new LicenseLicenseContext().GetAll());
        }

        public void AddLicense(string newLicenseName, int parentCode)
        {
            var licenseService = new LicenseService();
            var newCode = licenseService.GetNewCode(this.licenses);

            var newLicense = new License()
            {
                Name = newLicenseName,
                Code = newCode,
            };

            this.licenses.Add(newLicense);

            if (parentCode != 0)
            {
                var parentLicense = this.licenses.Where(l => l.Code == parentCode).First();

                var newRelation = new LicenseCodeRelation()
                {
                    ParentCode = parentLicense.Code,
                    ChildCode = newCode,
                };

                this.licenseCodeRelations.Add(newRelation);
            }
        }

        public IList<ComponentDto> GetTree()
        {
            return new LicenseService().BuildTree(licenses, licenseCodeRelations);
        }

        public void SaveChanges()
        {
            var licenseService = new LicenseService();

            var newLicenses = this.licenses;
            var newRelations = this.licenseCodeRelations;

            licenseService.AddLicensesAndRelations(newLicenses, newRelations);
        }
    }
}
