# PromoCodeFactory

Проект для домашнего задания по курсу `C# ASP.NET Core Разработчик` от `Отус`.
Cистема `Promocode Factory` для выдачи промокодов партнеров для клиентов по группам предпочтений.

Данный проект является стартовой точкой для Homework №2

# Описание
Система содержит базу клиентов с их предпочтениями (Семья, Дети, Театр, Бизнес, и т.д.) и позволяет партнёрам отсылать промокоды клиентам с выбранными предпочтениями.
Например, промокоды на билеты в театр будут разосланы клиентам с предпочтением "Театр".
При этом партнёр сам выбирает клиентам с какими предпочтениями рассылать выбранные промокоды и сделать он это может двумя способами: через партнерского менеджера или с помощью API.
Для отправки промокода клиентам менеджер может зайти в SPA интерфейс приложения и сделать выдачу промокода, полученного каким-то способом от партнера, например, по email. Промокод будет отправлен
всем клиентам с подходящим предпочтением.
Если партнер имеет возможности программной интеграции, то он может выдать промокоды по предпочтениям через api.
Для этого он запрашивает от API список предпочтений и передает нужное предпочтение вместе с промокодом.
Разрабатываемый фукнционал не будет включать сам механизм рассылки.
Система имеет два варианта архитектуры, для MVP мы рассматриваем небольшое монолитное приложение Otus.Teaching.PromoCodeFactory c API. Также есть микросервисный вариант реализации, где система разбивается на три микросервиса: Администрирование: Otus.Teaching.Pcf.Administration, Получение промокодов от партнеров:Otus.Teaching.Pcf.ReceivingFromPartner, Предложение промокодов клиентам: Otus.Teaching.Pcf.GivingToCustomer.
Микросервис администрирования отвечает за работу с сотрудниками (партнерскими менеджерами) и ролями. Микросервис Получение промокодов от партнеров отвечает за предоставление партнеру api для передачи промокода и также API для управления партнерами.
Микросервис Предложение промокодов клиентам отвечает за предоставление промокодов конкретным клиентам и потенциально за их рассылку.

# Основные функции
- Партнерский менеджер нашей компании может зайти в WEB-приложение сервиса PromoCodeFactory, выбрать предпочтение из списка и выдать промокод, полученный от партнера, после этого промокод будет выдан всем клиентам из клиентской базы, которые имеют данное предпочтение.
- Администратор сервиса может:
  - войти в приложение,
  - просмотреть список сотрудников,
  - создать нового сотрудника или отредактировать данные существующего;
  - посмотреть количество выданных промокодов сотрудником в информации о сотруднике;
  - выдавать промокоды, как и менеджер;
  - отменить лимит партнера или установить новый.
- Администратор и сотрудник должны авторизоваться.
- Партнер может через API создать новый промокод на предпочтение.
- Для того, чтобы партнер через API мог выдать промокоды по предпочтениям, мы предоставляем доступ к справочнику предпочтений через API.
- Система партнера может вызвать наше API, передать туда промокод с описанием услуги и предпочтением, после чего наша система отправит его подходящим клиентам.
- Система предоставляет закрытое CRUD API для работы с базой клиентов, в будущем менеджеры по работе с клиентами смогут наполнять базу через интерфейс, но пока это доступно только по API.
- Также есть функционал работы с партнерами:
  - для партнера устанавливаются лимиты на выдачу промокодов,
  - если лимит превышен или закончился срок его действия, то промокод нельзя выдать.
