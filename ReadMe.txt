Purpose of the application:
1. Support for SKU's own directory in the local database:
   - used ORM - Sql CE;
   - expansion options: adding I...Repository interfaces and corresponding implementations;
2. Update the availability, prices, new and outdated SKUs from suppliers by:
   - API - integration with vendor sites;
   - reading text files (csv / xml / ...);
   - requests to third-party databases;
   - expansion options: adding IProductsAgent implementations;
3. Export SKU catalog in the following formats:
   - text files (csv / xml / ...);
   - other databases;
   - expansion options: adding ISaver... interfaces and corresponding implementations;
4. Support for the schedule of automatic tasks;
5. Ability to upload image files to local directories.

Planned user roles and uses:
 Sales / Supply / Support online SKU status in the online store (or online price)

Technical description:
 Architecture: MVP (passive view), NET Framework 4.7.2
 Tests: MSTest
 Patterns: DI (Unity), Facade, Factory method
 Validation: FluentValidation