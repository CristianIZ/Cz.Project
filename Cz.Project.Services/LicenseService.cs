using Cz.Project.Abstraction;
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
        /// <summary>
        /// Get from database and builds the composite
        /// </summary>
        /// <returns></returns>
        public IList<ComponentDto> GetLicenseTree()
        {
            var licenses = new LicensesContext().GetAll();
            var licenseRelation = new LicenseLicenseContext().GetAll();



            return BuildTree(licenses, licenseRelation);
        }

        /// <summary>
        /// Builds a tree with given licenses and relations
        /// </summary>
        /// <param name="licenses">All the licenses</param>
        /// <param name="licenseRelation">All the relations</param>
        /// <returns></returns>
        public IList<ComponentDto> BuildTree(IList<License> licenses, IList<LicenseLicense> licenseRelation)
        {
            var rootLicenses = GetRootLicenses(licenses, licenseRelation);

            var linceseTree = new List<ComponentDto>();

            foreach (var rootlicense in rootLicenses)
            {
                var familyRoot = (FamilyLicenseDto)MapLicense(rootlicense, true);
                FillRootLicense(rootlicense, ref familyRoot, licenses, licenseRelation);
                linceseTree.Add(familyRoot);
            }

            return linceseTree;
        }

        private IList<License> GetRootLicenses(IList<License> licenses, IList<LicenseLicense> licenseRelation)
        {
            IList<License> rootLicenses = new List<License>();

            // Recorro todas las licencias
            foreach (var license in licenses)
            {
                // Cuando no es hijo de nadie es Root
                if (licenseRelation.Where(lr => lr.IdHijo == license.Id).Count() == 0)
                    rootLicenses.Add(license);
            }

            return rootLicenses;
        }

        /// <summary>
        /// Recursive function that build the tree for the given license
        /// </summary>
        private void FillRootLicense(License rootLic, ref FamilyLicenseDto familyRoot, IList<License> licenses, IList<LicenseLicense> relations)
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
        private IList<License> GetChilds(License license, IList<License> licenses, IList<LicenseLicense> relations)
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

        public IList<LicenseCodeRelation> MapToCodeRelation(IList<License> licenses, IList<LicenseLicense> licenseRelation)
        {
            return licenseRelation.Select(lr => new LicenseCodeRelation()
            {
                ChildCode = licenses.Where(l => l.Id == lr.IdHijo).First().Code,
                ParentCode = licenses.Where(l => l.Id == lr.IdPadre).First().Code
            }).ToList();
        }
    }
}
