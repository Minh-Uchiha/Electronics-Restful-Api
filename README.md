# Electronics-Restful-Api
An API that supports multiple requests from client side to interact with database that stored electronics devices information
## API url: 
https://electronicswebapi.azurewebsites.net

## Laptops
__Get__: https://electronicswebapi.azurewebsites.net/api/Laptops <br/>
__Get(Details)__: https://electronicswebapi.azurewebsites.net/api/Laptops/GetAllLaptopsDetails <br/>
__Get(id)__: https://electronicswebapi.azurewebsites.net/api/Laptops/{Id} <br/>
__Get(All keyboards that are compatible with this laptop)__: https://electronicswebapi.azurewebsites.net/api/Laptops/GetAllCompatibleKeyboards/{Id} <br/>
__Get(All headphones that are compatible with this laptop)__: https://electronicswebapi.azurewebsites.net/api/Laptops/GetAllCompatibleHeadphones/{Id} <br/>
__Get(Search all laptops that are within a range of price)__: https://electronicswebapi.azurewebsites.net/api/Laptops/SearchByPriceRange?lowerBound={lowerBound}&upperBound={upperBound} <br/>
__Get(Search by Name)__: https://electronicswebapi.azurewebsites.net/api/Laptops/SearchByName?query={query} <br/>
__Post__: https://electronicswebapi.azurewebsites.net/api/Laptops <br/>
__Put__: https://electronicswebapi.azurewebsites.net/api/Laptops <br/>

## Phones
__Get__: https://electronicswebapi.azurewebsites.net/api/Phones <br/>
__Get(id)__: https://electronicswebapi.azurewebsites.net/api/Phones/{Id} <br/>
__Get(Details)__: https://electronicswebapi.azurewebsites.net/api/Phones/GetAllPhonessDetails <br/>
__Get(All headphones that are compatible with this phone)__: https://electronicswebapi.azurewebsites.net/api/Phones/GetAllCompatibleHeadphones/{Id} <br/>
__Get(Search by Name)__: https://electronicswebapi.azurewebsites.net/api/Phones/SearchByName?query={query} <br/>
__Get(Search all phones that are within a range of price)__: https://electronicswebapi.azurewebsites.net/api/Phones/SearchByPriceRange?lowerBound={lowerBound}&upperBound={upperBound} <br/>
__Post__: https://electronicswebapi.azurewebsites.net/api/Phones <br/>
__Put__: https://electronicswebapi.azurewebsites.net/api/Phones <br/>

## Headphones
__Get__: https://electronicswebapi.azurewebsites.net/api/Headphones <br/>
__Get(id)__: https://electronicswebapi.azurewebsites.net/api/Headphones/{Id} <br/>
__Get(Details)__: https://electronicswebapi.azurewebsites.net/api/Headphones/GetAllHeadphonesDetails <br/>
__Get(Search by Name)__: https://electronicswebapi.azurewebsites.net/api/Headphones/SearchByName?query={query} <br/>
__Get(Search all headphones that are within a range of price)__: https://electronicswebapi.azurewebsites.net/api/Headphones/SearchByPriceRange?lowerBound={lowerBound}&upperBound={upperBound} <br/>
__Get(All headphones that are compatible with a specific phone)__: https://electronicswebapi.azurewebsites.net/api/Headphones/GetHeadphonesByCompatiblePhone?PhoneName={PhoneName} <br/>
__Get(All headphones that are compatible with a specific laptop)__: https://electronicswebapi.azurewebsites.net/api/Headphones/GetHeadphonesByCompatibleLaptop?LaptopName={LaptopName} <br/>
__Post__: https://electronicswebapi.azurewebsites.net/api/Headphones <br/>
__Put__: https://electronicswebapi.azurewebsites.net/api/Headphones <br/>

## Keyboards
__Get__: https://electronicswebapi.azurewebsites.net/api/Keyboards <br/>
__Get(id)__: https://electronicswebapi.azurewebsites.net/api/Keyboards/{Id} <br/>
__Get(Details)__: https://electronicswebapi.azurewebsites.net/api/Laptops/GetAllKeyboardsDetails <br/>
__Get(Search by Name)__: https://electronicswebapi.azurewebsites.net/api/Keyboards/SearchByName?query={query} <br/>
__Get(Search all keyboards that are within a range of price)__: https://electronicswebapi.azurewebsites.net/api/Keyboards/SearchByPriceRange?lowerBound={lowerBound}&upperBound={upperBound} <br/>
__Get(All headphones that are compatible with a specific lapto__: https://electronicswebapi.azurewebsites.net/api/Keyboards/GetHeadphonesByCompatibleLaptop?LaptopName={LaptopName} <br/>
__Post__: https://electronicswebapi.azurewebsites.net/api/Keyboards <br/>
__Put__: https://electronicswebapi.azurewebsites.net/api/Keyboards <br/>
 
