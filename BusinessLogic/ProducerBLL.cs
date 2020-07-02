using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ProducerBLL
    {
        MinhHungShopContext _context = new MinhHungShopContext();
        private static ProducerBLL Ins;

        private ProducerBLL()
        {

        }

        public static ProducerBLL getIns()
        {
            if (Ins == null)
            {
                Ins = new ProducerBLL();
            }
            return Ins;
        }

        public async Task<Utils.Status> Create(Producer Producer)
        {
            // handle 
            try
            {
                Producer pro = Producer;

                _context.Add(pro);
                await _context.SaveChangesAsync();
                // return the status of handle: success or failed or...
                return Utils.Status.Success;
            }
            catch (Exception e)
            {
                return Utils.Status.Failed;
            }
        }

        public async Task<List<Producer>> GetProducers(string searchText="")
        {
            List<Producer> producers = await _context.Producer.ToListAsync();
            if(searchText!=null && searchText != "")
                producers = producers.FindAll(delegate (Producer p)
                    {
                        return p.Name.Contains(searchText);
                    });
            return producers;
        }

        public async Task<Utils.Status> Delete(long id)
        {
            // handle 
            try
            {
                var Producer = await _context.Producer.FindAsync(id);
                _context.Producer.Remove(Producer);
                await _context.SaveChangesAsync();
                return Utils.Status.Success;
            }
            catch (Exception e)
            {
                return Utils.Status.Failed;
            }
        }

        public async Task<Utils.Status> Update(Producer producer)
        {
            try
            {
                Producer iProducer = await GetProducer(producer.Id);
                iProducer.Name = producer.Name;
                iProducer.Description = producer.Description;
                _context.Producer.Update(iProducer);
                await _context.SaveChangesAsync();
                return Utils.Status.Success;
            }
            catch (Exception e)
            {
                return Utils.Status.Failed;
            }
        }

        public async Task<Producer> GetProducer(long? id)
        {
            try
            {
                if (id == null)
                {
                    return null;
                }

                return _context.Producer.Find(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }
      
    }
}
