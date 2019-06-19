using FinTax.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace FinTax.DataAccess.InMemory
{
    public class COAAttachmentRepository
    {
        ObjectCache cache = MemoryCache.Default;

        List<COAAttachment> coaAttachments = new List<COAAttachment>();

        public COAAttachmentRepository()
        {
            coaAttachments = cache["coaAttachments"] as List<COAAttachment>;

            if (coaAttachments == null)
            {
                coaAttachments = new List<COAAttachment>();
            }
        }

        public void Commit()
        {
            cache["coaAttachments"] = coaAttachments;
        }

        public void Insert(COAAttachment p)
        {
            coaAttachments.Add(p);
        }

        public void Update(COAAttachment coaAttachment)
        {
            COAAttachment coaAttachmentToUpdate = coaAttachments.Find(p => p.Id == coaAttachment.Id);

            if (coaAttachmentToUpdate != null)
            {
                coaAttachmentToUpdate = coaAttachment;
            }
            else
            {
                throw new Exception("COA Attachment not found");
            }
        }

        public COAAttachment Find(string id)
        {
            COAAttachment coaAttachment = coaAttachments.Find(p => p.Id == id);
            if (coaAttachment != null)
            {
                return coaAttachment;
            }
            else
            {
                throw new Exception("COA Attachment not found");
            }
        }

        public IQueryable<COAAttachment> Collection()
        {
            return coaAttachments.AsQueryable();
        }

        public void Delete(string id)
        {
            COAAttachment coaAttachmentToDelete = coaAttachments.Find(p => p.Id == id);
            if (coaAttachmentToDelete != null)
            {
                coaAttachments.Remove(coaAttachmentToDelete);
            }
            else
            {
                throw new Exception("COA AttachmentToDelete not found");
            }
        }
    }
}
