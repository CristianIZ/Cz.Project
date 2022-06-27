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
            this.licenses = new LicensesContext().GetAll();
            this.licensesRelation = new LicenseLicenseContext().GetAll();
        }

        public void AddLicense(string newLicenseName, int parentCode)
        {
            var parentLicense = this.licenses.Where(l => l.Code == parentCode).First();

            var license = new License()
            {
                Name = newLicenseName,
                Code = parentCode,
            };

            var relation = new LicenseLicense()
            {

            };

            this.licenses.Add(license);
            this.licenseCodeRelations.Add();
        }

        /// <summary>
        /// Populate lists from given lists
        /// </summary>
        /// <param name="licenses">List to store in memory</param>
        /// <param name="licensesRelation">Relations to store in memory</param>
        public InMemoryLicenses(IList<License> licenses, IList<LicenseLicense> licensesRelation)
        {
            this.licenses = licenses;
            this.licensesRelation = licensesRelation;
        }

        public IList<ComponentDto> GetTree()
        {
            return new LicenseService().BuildTree(licenses, licensesRelation);
        }
    }
}
