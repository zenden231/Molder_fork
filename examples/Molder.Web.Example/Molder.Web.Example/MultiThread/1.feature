﻿@WebUI
@ignore
Feature: Task #1

Scenario: OpenWebUI
	Given я инициализирую браузер
		And я развернул веб-страницу на весь экран
		And я перехожу на страницу "InternetHerokuapp"
		And я закрываю веб-страницу
		And я закрываю браузер