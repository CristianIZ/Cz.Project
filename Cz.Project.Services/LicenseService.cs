using Cz.Project.Domain;
using Cz.Project.Dto;
using Cz.Project.SQLContext.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cz.Project.Services
{
    public class LicenseService
    {
        public IList<ComponentDto> GetLicenseTree()
        {
            var licenseContext = new LicensesContext();
            var licenselicenseContext = new LicenseLicenseContext();

            var licenses = licenseContext.GetAll();
            var licenseRelation = licenselicenseContext.GetAll();

            IList<ComponentDto> familyRootLicenses = new List<ComponentDto>();
            IList<License> rootLicenses = new List<License>();

            foreach (var license in licenses)
            {
                if (licenseRelation.Where(lr => lr.IdHijo == license.Id).Count() == 0)
                {
                    familyRootLicenses.Add(MapLicense(license, true));
                    rootLicenses.Add(license);
                }
            }

            var linceseTree = new List<ComponentDto>();

            foreach (var rootlicense in rootLicenses)
            {
                var familyRoot = (FamilyLicenseDto)MapLicense(rootlicense, true);
                FillRootLicense(rootlicense, ref familyRoot, licenses, licenseRelation);
                linceseTree.Add(familyRoot);
            }

            return linceseTree;
        }

        /// <summary>
        /// Recursive function that build the tree for the given license
        /// </summary>
        public void FillRootLicense(License rootLic, ref FamilyLicenseDto familyRoot, IList<License> licenses, IList<LicenseLicense> relations)
        {
            var childs = GetChilds(rootLic, licenses, relations);

            foreach (var item in childs)
            {
                if (GetChilds(item, licenses, relations).Count > 0)
                {
                    var family = (FamilyLicenseDto)MapLicense(item, true);
                    familyRoot.AddChild(family);
                    FillRootLicense(item, ref family, licenses, relations);
                }
                else
                {
                    familyRoot.AddChild(MapLicense(item, false));
                }
            }
        }

        /// <summary>
        /// Look for all the childs of the license
        /// </summary>
        public IList<License> GetChilds(License license, IList<License> licenses, IList<LicenseLicense> relations)
        {
            var childRelations = relations.Where(r => r.IdPadre == license.Id).ToList();

            IList<License> result = new List<License>();

            foreach (var item in childRelations)
            {
                result.Add(licenses.Where(l => l.Id == item.IdHijo).First());
            }

            return result;
        }

        public ComponentDto MapLicense(License license, bool hasChilds)
        {
            if (hasChilds)
                return new FamilyLicenseDto(license.Name, 0);
            else
                return new LicenseDto(license.Name, 0);
        }
    }
}
