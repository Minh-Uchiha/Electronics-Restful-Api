# Electronics-Restful-Api
An API that supports multiple requests from client side to interact with database that stored electronics devices information
## API url: 
https://electronicswebapi.azurewebsites.net

## Laptops
Get: https://electronicswebapi.azurewebsites.net/api/Laptops
Get(Details): https://electronicswebapi.azurewebsites.net/api/Laptops/GetAllLaptopsDetails
Get(id): https://electronicswebapi.azurewebsites.net/api/Laptops/{Id}
Get(All keyboards that are compatible with this laptop): https://electronicswebapi.azurewebsites.net/api/Laptops/GetAllCompatibleKeyboards/{Id}
Get(All headphones that are compatible with this laptop): https://electronicswebapi.azurewebsites.net/api/Laptops/GetAllCompatibleHeadphones/{Id}
Get(Search all laptops that are within a range of price): https://electronicswebapi.azurewebsites.net/api/Laptops/SearchByPriceRange?lowerBound={lowerBound}&upperBound={upperBound}
Get(Search by Name): https://electronicswebapi.azurewebsites.net/api/Laptops/SearchByName?query={query}
Post: https://electronicswebapi.azurewebsites.net/api/Laptops
Put: https://electronicswebapi.azurewebsites.net/api/Laptops

## Phones
Get: https://electronicswebapi.azurewebsites.net/api/Phones
Get(id): https://electronicswebapi.azurewebsites.net/api/Phones/{Id}
Get(Details): https://electronicswebapi.azurewebsites.net/api/Phones/GetAllPhonessDetails
Get(All headphones that are compatible with this phone): https://electronicswebapi.azurewebsites.net/api/Phones/GetAllCompatibleHeadphones/{Id}
Get(Search by Name): https://electronicswebapi.azurewebsites.net/api/Phones/SearchByName?query={query}
Get(Search all phones that are within a range of price): https://electronicswebapi.azurewebsites.net/api/Phones/SearchByPriceRange?lowerBound={lowerBound}&upperBound={upperBound}
Post: https://electronicswebapi.azurewebsites.net/api/Phones
Put: https://electronicswebapi.azurewebsites.net/api/Phones

## Headphones
Get: https://electronicswebapi.azurewebsites.net/api/Headphones
Get(id): https://electronicswebapi.azurewebsites.net/api/Headphones/{Id}
Get(Details): https://electronicswebapi.azurewebsites.net/api/Headphones/GetAllHeadphonesDetails
Post: https://electronicswebapi.azurewebsites.net/api/Headphones
Put: https://electronicswebapi.azurewebsites.net/api/Headphones

## Keyboards
Get: https://electronicswebapi.azurewebsites.net/api/Keyboards
Get(id): https://electronicswebapi.azurewebsites.net/api/Keyboards/{Id}
Get(Details): https://electronicswebapi.azurewebsites.net/api/Laptops/GetAllKeyboardsDetails
Post: https://electronicswebapi.azurewebsites.net/api/Keyboards
Put: https://electronicswebapi.azurewebsites.net/api/Keyboards
