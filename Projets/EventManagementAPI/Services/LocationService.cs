using EventManagementAPI.Dtos;
using EventManagementAPI.Interfaces;
using EventManagementAPI.Models;
using EventManagementAPI.Repository;

namespace EventManagementAPI.Services
{
    public class LocationService(ILocationRepository locationRepository) : ILocationService
    {
        private readonly ILocationRepository _locationRepository = locationRepository ?? throw new ArgumentNullException(nameof(locationRepository));
        // Consider adding ILogger for logging

        /// <summary>
        /// Récupère toutes les locations.
        /// </summary>
        /// <returns>
        /// Une tâche représentant l'opération asynchrone. Le résultat de la tâche contient une collection
        /// d'objets <see cref="LocationDto"/> représentant toutes les locations.
        /// </returns>
        /// <remarks>
        /// Cette méthode interroge le dépôt de locations pour récupérer toutes les locations. Les données sont ensuite
        /// projetées sous forme de collection d'objets <see cref="LocationDto"/>. Le mappage est effectué manuellement,
        /// mais il est recommandé d'utiliser un outil comme AutoMapper pour des projets plus importants.
        /// </remarks>
        public async Task<IEnumerable<LocationDto>> GetAllLocationsAsync()
        {
            var locations = await _locationRepository.GetAllAsync();
            // Manual mapping (Consider AutoMapper for larger projects)
            return locations.Select(l => new LocationDto
            {
                Id = l.Id,
                Name = l.Name,
                Address = l.Address
            });
        }

        /// <summary>
        /// Récupère une location par son identifiant unique.
        /// </summary>
        /// <param name="id">L'identifiant de la location à récupérer.</param>
        /// <returns>
        /// Une tâche représentant l'opération asynchrone. Le résultat de la tâche contient un objet <see cref="LocationDto"/> 
        /// correspondant à la location spécifiée, ou <c>null</c> si aucune location n'est trouvée avec cet identifiant.
        /// </returns>
        /// <remarks>
        /// Cette méthode interroge le dépôt de locations pour récupérer une location spécifique par son identifiant.
        /// Si aucune location n'est trouvée, la méthode retourne <c>null</c>. Le mappage des données est effectué manuellement.
        /// </remarks>
        public async Task<LocationDto?> GetLocationByIdAsync(int id)
        {
            var location = await _locationRepository.GetByIdAsync(id);
            if (location == null)
            {
                return null;
            }

            // Manual mapping
            return new LocationDto
            {
                Id = location.Id,
                Name = location.Name,
                Address = location.Address
            };
        }

        /// <summary>
        /// Crée une nouvelle location à partir des données fournies.
        /// </summary>
        /// <param name="locationDto">Les informations de la location à créer.</param>
        /// <returns>
        /// Une tâche représentant l'opération asynchrone. Le résultat de la tâche contient un objet <see cref="LocationDto"/>
        /// représentant la location créée, incluant son identifiant généré.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Levée si le nom de la location est vide ou constitué uniquement d'espaces blancs.
        /// </exception>
        /// <remarks>
        /// La méthode effectue une validation basique du nom de la location.
        /// Le mappage des données est effectué manuellement.
        /// Après la création, le DTO est mis à jour avec l'identifiant généré par la base de données avant d'être retourné.
        /// Il est recommandé de déplacer la validation dans un validateur dédié pour une meilleure maintenabilité.
        /// </remarks>
        public async Task<LocationDto> CreateLocationAsync(LocationDto locationDto)
        {
            // Basic validation example (move to dedicated validator later)
            if (string.IsNullOrWhiteSpace(locationDto.Name))
            {
                throw new ArgumentException("Location name cannot be empty.", nameof(locationDto.Name));
            }

            // Manual mapping
            var location = new Location
            {
                Name = locationDto.Name,
                Address = locationDto.Address
            };

            await _locationRepository.AddAsync(location);
            await _locationRepository.SaveChangesAsync(); // Assuming SaveChanges is called here

            // Update DTO with generated ID and return
            locationDto.Id = location.Id;
            return locationDto;
        }

        /// <summary>
        /// Met à jour les informations d'une location existante.
        /// </summary>
        /// <param name="id">L'identifiant de la location à mettre à jour.</param>
        /// <param name="locationDto">Les nouvelles données de la location.</param>
        /// <returns>
        /// Une tâche représentant l'opération asynchrone. Le résultat de la tâche contient un booléen indiquant si la mise à jour a réussi.
        /// Retourne <c>false</c> si la location n'a pas été trouvée ; sinon, <c>true</c>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Levée si le nom de la location est vide ou constitué uniquement d'espaces blancs.
        /// </exception>
        /// <remarks>
        /// La méthode vérifie d'abord l'existence de la location.  
        /// Une validation basique du nom de la location est effectuée.
        /// Le mappage des données est manuel.
        /// Comme le contexte EF Core suit déjà les entités, un appel à <c>SaveChangesAsync</c> suffit pour enregistrer les modifications.
        /// Il est recommandé d'ajouter un validateur dédié pour centraliser la logique de validation.
        /// </remarks>
        public async Task<bool> UpdateLocationAsync(int id, LocationDto locationDto)
        {
            var location = await _locationRepository.GetByIdAsync(id);
            if (location == null)
            {
                return false; // Indicate not found
            }

            // Basic validation
            if (string.IsNullOrWhiteSpace(locationDto.Name))
            {
                throw new ArgumentException("Location name cannot be empty.", nameof(locationDto.Name));
            }

            // Manual mapping
            location.Name = locationDto.Name;
            location.Address = locationDto.Address;

            // The Repository doesn't have an Update method in this setup.
            // EF Core tracks changes, so SaveChangesAsync is enough.
            await _locationRepository.SaveChangesAsync();
            return true; // Indicate success
        }

        /// <summary>
        /// Supprime une location existante à partir de son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant de la location à supprimer.</param>
        /// <returns>
        /// Une tâche représentant l'opération asynchrone. Le résultat de la tâche contient un booléen indiquant si la suppression a réussi.
        /// Retourne <c>false</c> si la location n'a pas été trouvée ; sinon, <c>true</c>.
        /// </returns>
        /// <remarks>
        /// La méthode vérifie d'abord si la location existe.
        /// Si elle est trouvée, elle est supprimée du contexte, puis les modifications sont enregistrées.
        /// </remarks>
        public async Task<bool> DeleteLocationAsync(int id)
        {
            var location = await _locationRepository.GetByIdAsync(id);
            if (location == null)
            {
                return false; // Indicate not found
            }

            _locationRepository.Remove(location);
            await _locationRepository.SaveChangesAsync();
            return true; // Indicate success
        }
    }
}