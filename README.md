# brazilian-phone-formatter
A compact and understandable library that formats all (or almost all) types of Brazilian numbers using C#. The focus is on making it easy to maintain with simplicity for adding new formats.

## Number formats
- Mobile phone
- Home phone 
- Non-geographic 
- Public utility
- Service provider extension

## Conversions
- Landline Numbers: Starting with 2, 3, 4, and 5
| Country Code | Area Code | Number | Formatted Number  |
| :-------------------------: | :---------------------: | :----------: | :----------------------------------------------------------------------------------------------------------------------------------------- |
|    `55`    |        `47`         |     `33251368`     | `+55 (47) 3325-1368` |

- Mobile Numbers: Starting with 7, 8, or 9
| Country Code | Area Code | Number | Formatted Number  |
| :-------------------------: | :---------------------: | :----------: | :----------------------------------------------------------------------------------------------------------------------------------------- |
|    `55`    |        `47`         |     `84461240 (without ninth digit)`     | `+55 (47) 8446-1240` |
|    `55`    |        `47`         |     `984461240 (with ninth digit)`     | `+55 (47) 9 8446-1240` |

- Public Utility and Emergency Service Numbers (SUP) – 3 digits
| Service Name | Number | Formatted Number  |
| :-------------------------: | :---------------------: |:----------------------------------------------------------------------------------------------------------------------------------------- |
|`Municipal Guard`                             |   `153`   |    `153`    |
|`Complaint Hotline`                              |   `181`   |    `181`    |
|`Military Police`                              |   `190`   |    `190`    |
|`Federal Highway Police`                   |   `191`   |    `191`    |
|`Emergency Medical Service`    |   `192`   |    `192`    |
|`Fire Department`                           |   `193`   |    `193`    |
|`Civil Police`                                |   `197`   |    `197`    |
|`Federal Police`                   |   `198`   |    `198`    |
|`Civil Defense`                                 |   `199`   |    `199`    |
|`Consumer Protection`                                       |   `151`   |    `151`    |
|`Department of Traffic`                                       |   `154`   |    `154`    |


- Extensions of numbers from providers of landline, mobile, and subscription TV services
| Provider | Prefix | Number | Formatted Number | 
| :-------------------------: | :---------------------: | :----------: | :----------------------------------------------------------------------------------------------------------------------------------------- |
| `Embratel`                             |  `103 (landline)`    |   `21`  |   `10321`     |
| `Brasil Telecom`                       |  `103 (landline)`    |   `14`  |   `10314`     |
| `Claro`                                |  `105 (mobile)`   |   `2`   |   `1052`      |
| `Tim`                                  |  `105 (mobile)`   |   `6`   |   `1056`      |
| `GVT`                                  |  `106 (subscription TV)` |   `25`  |   `10625`     |
| `Telefônica Sistema de Televisão S.A`  |  `106 (subscription TV)` |   `77`  |   `10677`     |        


- Non-geographic Numbers
| Type | Description | Number | Formatted Number | 
| :-------------------------: | :---------------------: | :----------: | :----------------------------------------------------------------------------------------------------------------------------------------- |
| `0300`  |  `Charged on a shared basis: user pays local segment, and provider assumes costs of long-distance segment.`    |   `03007291247`  |   `0300 729 1247`     |
| `0500`  |  `Service for donation campaigns`                             |   `05007294586`  |   `0500 729 4586`     |
| `0800`  |  `Paid for by the subscriber of the receiving service`    |   `08007294568`  |   `0800 729 4568`     |



## Installing
Download or copy the class to your project and use the method `Format`.

## Use/Samples
You can use the formatter like this:

- Mobile phone number format.
```CSharp
Format("12982034955")
```
The output will be `(12)98203-4955`.


- Non-geographic number format
```CSharp
Format("08007294568")
```
The output will be `0800 729 4568`.


- Home phone number format

```CSharp
Format("554733251368")
```
The output will be `+55 (47) 3325-1368`


## License

[![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](http://badges.mit-license.org)

- **[MIT license](http://opensource.org/licenses/mit-license.php)**
