using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ContactServices
{
    public class ContactService:IContactService
    {
        private readonly IMongoCollection<Contact> _mongoCollection;
        private readonly IMapper _mapper;

        public ContactService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _mongoCollection = database.GetCollection<Contact>(databaseSettings.ContactCollectionName);
            _mapper = mapper;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            var value = _mapper.Map<Contact>(createContactDto);
            await _mongoCollection.InsertOneAsync(value);
        }

        public async Task DeleteContactAsync(string id)
        {
            await _mongoCollection.DeleteOneAsync(x => x.ContactId == id);
        }

        public async Task<List<ResultContactDto>> GetAllContactsAsync()
        {
            var values = await _mongoCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultContactDto>>(values);
        }

        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
            var values = await _mongoCollection.Find<Contact>(x => x.ContactId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdContactDto>(values);
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            var values = _mapper.Map<Contact>(updateContactDto);
            await _mongoCollection.FindOneAndReplaceAsync(x => x.ContactId == updateContactDto.ContactId, values);
        }
    }
}
