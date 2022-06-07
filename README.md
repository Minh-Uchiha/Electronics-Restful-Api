# Electronics-Restful-Api
An API that supports multiple requests from client side to interact with database that stored electronics devices information
## API url: 
https://electronicswebapi.azurewebsites.net

## Laptops
Get: https://electronicswebapi.azurewebsites.net/api/Laptops <br/>
Get(Details): https://electronicswebapi.azurewebsites.net/api/Laptops/GetAllLaptopsDetails <br/>
Get(id): https://electronicswebapi.azurewebsites.net/api/Laptops/{Id} <br/>
Get(All keyboards that are compatible with this laptop): https://electronicswebapi.azurewebsites.net/api/Laptops/GetAllCompatibleKeyboards/{Id} <br/>
Get(All headphones that are compatible with this laptop): https://electronicswebapi.azurewebsites.net/api/Laptops/GetAllCompatibleHeadphones/{Id} <br/>
Get(Search all laptops that are within a range of price): https://electronicswebapi.azurewebsites.net/api/Laptops/SearchByPriceRange?lowerBound={lowerBound}&upperBound={upperBound} <br/>
Get(Search by Name): https://electronicswebapi.azurewebsites.net/api/Laptops/SearchByName?query={query} <br/>
Post: https://electronicswebapi.azurewebsites.net/api/Laptops <br/>
Put: https://electronicswebapi.azurewebsites.net/api/Laptops <br/>

## Phones
Get: https://electronicswebapi.azurewebsites.net/api/Phones <br/>
Get(id): https://electronicswebapi.azurewebsites.net/api/Phones/{Id} <br/>
Get(Details): https://electronicswebapi.azurewebsites.net/api/Phones/GetAllPhonessDetails <br/>
Get(All headphones that are compatible with this phone): https://electronicswebapi.azurewebsites.net/api/Phones/GetAllCompatibleHeadphones/{Id} <br/>
Get(Search by Name): https://electronicswebapi.azurewebsites.net/api/Phones/SearchByName?query={query} <br/>
Get(Search all phones that are within a range of price): https://electronicswebapi.azurewebsites.net/api/Phones/SearchByPriceRange?lowerBound={lowerBound}&upperBound={upperBound} <br/>
Post: https://electronicswebapi.azurewebsites.net/api/Phones <br/>
Put: https://electronicswebapi.azurewebsites.net/api/Phones <br/>

## Headphones
Get: https://electronicswebapi.azurewebsites.net/api/Headphones <br/>
Get(id): https://electronicswebapi.azurewebsites.net/api/Headphones/{Id} <br/>
Get(Details): https://electronicswebapi.azurewebsites.net/api/Headphones/GetAllHeadphonesDetails <br/>
Get(Search by Name): https://electronicswebapi.azurewebsites.net/api/Headphones/SearchByName?query={query} <br/>
Get(Search all headphones that are within a range of price): https://electronicswebapi.azurewebsites.net/api/Headphones/SearchByPriceRange?lowerBound={lowerBound}&upperBound={upperBound} <br/>
Get(All headphones that are compatible with a specific phone): https://electronicswebapi.azurewebsites.net/api/Headphones/GetHeadphonesByCompatiblePhone?PhoneName={PhoneName} <br/>
Get(All headphones that are compatible with a specific laptop): https://electronicswebapi.azurewebsites.net/api/Headphones/GetHeadphonesByCompatibleLaptop?LaptopName={LaptopName} <br/>
Post: https://electronicswebapi.azurewebsites.net/api/Headphones <br/>
Put: https://electronicswebapi.azurewebsites.net/api/Headphones <br/>

## Keyboards
Get: https://electronicswebapi.azurewebsites.net/api/Keyboards <br/>
Get(id): https://electronicswebapi.azurewebsites.net/api/Keyboards/{Id} <br/>
Get(Details): https://electronicswebapi.azurewebsites.net/api/Laptops/GetAllKeyboardsDetails <br/>
Get(Search by Name): https://electronicswebapi.azurewebsites.net/api/Keyboards/SearchByName?query={query} <br/>
Get(Search all keyboards that are within a range of price): https://electronicswebapi.azurewebsites.net/api/Keyboards/SearchByPriceRange?lowerBound={lowerBound}&upperBound={upperBound} <br/>
Get(All headphones that are compatible with a specific laptop): https://electronicswebapi.azurewebsites.net/api/Keyboards/GetHeadphonesByCompatibleLaptop?LaptopName={LaptopName} <br/>
Post: https://electronicswebapi.azurewebsites.net/api/Keyboards <br/>
Put: https://electronicswebapi.azurewebsites.net/api/Keyboards <br/>
 
