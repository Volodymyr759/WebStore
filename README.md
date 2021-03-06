# WebStore
Application for support for SKU's own directory in the local database

Purpose of the application:
1. Support for SKU's own directory in the local database:
   - used ORM - Sql CE;
   - expansion posibilities: adding I...Repository interfaces and corresponding implementations;
2. Update the availability, prices, new and outdated SKUs from suppliers by:
   - API - integration with vendor sites;
   - reading text files (csv / xml / ...);
   - requests to third-party databases;
   - expansion posibilities: adding IProductsAgent implementations;
3. Export SKU catalog in the following formats:
   - text files (csv / xml / ...);
   - other databases;
   - expansion posibilities: adding ISaver... interfaces and corresponding implementations;
4. Support for the schedule of automatic tasks;
5. Ability to upload image files to local directories.

Planned user roles and uses:
 Sales / Supply / Support online SKU status in the online store (or online price)

Technical description:
 NET Framework 4.7.2
 Tests: MSTest (Moq)
 Patterns: MVP (passive view), DI (Unity), Facade, Factory method
 Validation: FluentValidation
