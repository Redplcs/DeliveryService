# DeliveryService

Тестовое задание для службы доставки. Заказы принимаются через IOrderProvider, передаются в OrderFilteringService, фильтруются через IOrderFilter (DeliveryTimeOrderFilter, DistrictIdOrderFilter) и отправляются через IOrderSender интерфейс.

# Запуск

Для работы, необходимо указать два параметра - _inputOrder (вводные данные в текстовом формате) и _deliveryOrder (вывод результата в файл). Указать параметры можно как в переменной окружения, так и в аргументы (--{имя}="{значение}").

В репозитории уже имеется [текстовый файл](https://github.com/Redplcs/DeliveryService/blob/master/src/OrderFiltering/Application/src/input.txt) с тестовыми значениями. 

Для фильтрации: _cityDistrict для фильтрации по указанному адресу доставки; _firstDeliveryDateTime для фильтрации по дате доставки в промежутке 30 минут.

Для сохранения логов в файл, указываете в переменную _deliveryLog путь до файла. Создавать не обязательно, приложение само создает файл по указанному пути.
