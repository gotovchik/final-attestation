# Итоговая контрольная работа

## Информация о проекте

Необходимо организовать систему учета для питомника, в котором живут домашние и вьючные животные.

## Как сдавать проект

Для сдачи проекта необходимо создать отдельный общедоступный
репозиторий(Github).  
Разработку вести в этом репозитории, использовать пул реквесты на изменения.  
Программа должна запускаться и работать, ошибок при выполнении программы быть не должно.  

## Задания и ход выполнения работы

Создал репозиторий на github. Далее создал рабочую директорию и клонировал репозиторий.

```shell
mkdir final-attestation
cd .\final-attestation\
git clone https://github.com/gotovchik/final-attestation.git
```

1. Используя команду cat в терминале операционной системы Linux, создать
два файла Домашние животные (заполнив файл собаками, кошками,
хомяками) и Вьючные животными заполнив файл Лошадьми, верблюдами и
ослы), а затем объединить их. Просмотреть содержимое созданного файла.
Переименовать файл, дав ему новое имя (Друзья человека).
![Команды Linux](images/linux1.png)
2. Создать директорию, переместить файл туда.
![Команды Linux](images/linux2.png)
3. Подключить дополнительный репозиторий MySQL. Установить любой пакет
из этого репозитория.
4. Установить и удалить deb-пакет с помощью dpkg.
5. Выложить историю команд в терминале ubuntu
![Команды Linux](images/linux3.png)
6. Нарисовать диаграмму, в которой есть класс родительский класс, домашние
животные и вьючные животные, в составы которых в случае домашних
животных войдут классы: собаки, кошки, хомяки, а в класс вьючные животные
войдут: Лошади, верблюды и ослы.
![Диаграмма](images/diagram.drawio.png)
7. В подключенном MySQL репозитории создать базу данных “Друзья
человека”

```sql
CREATE DATABASE "HumanFriends"
```

8. Создать таблицы с иерархией из диаграммы в БД
9. Заполнить низкоуровневые таблицы именами(животных), командами
которые они выполняют и датами рождения

<details>
<summary>SQL-запросы</summary>

```sql
--DROP TABLE IF EXISTS animals_groups

CREATE TABLE IF NOT EXISTS animal_groups
(
 group_id serial PRIMARY KEY,
 group_name VARCHAR(20) NOT NULL
);

INSERT INTO animal_groups (group_name)
VALUES
('вьючные'),
('домашние');

--DROP TABLE IF EXISTS pack_animals

CREATE TABLE IF NOT EXISTS pack_animals
(
 animal_id serial PRIMARY KEY,
 animal_name VARCHAR(20) NOT NULL,
 group_id int NOT NULL,
 FOREIGN KEY (group_id) REFERENCES animals_groups (group_id) 
);

INSERT INTO pack_animals (animal_name, group_id)
VALUES
('Лошади', 1),
('Ослы', 1),
('Верблюды', 1);

--DROP TABLE IF EXISTS pets

CREATE TABLE IF NOT EXISTS pets
(
 pet_id serial PRIMARY KEY,
 pet_name VARCHAR(20) NOT NULL,
 group_id int NOT NULL,
 FOREIGN KEY (group_id) REFERENCES animals_groups (group_id) 
);

INSERT INTO pets (pet_name, group_id)
VALUES
('Кошки', 2),
('Собаки', 2),
('Хомяки', 2);

--DROP TABLE IF EXISTS donkeys

CREATE TABLE IF NOT EXISTS donkeys
(
 donkey_id serial PRIMARY KEY,
 donkey_name VARCHAR(20)  NOT NULL,
 birthday DATA NOT NULL,
 command VARCHAR(20),
 animal_id int NOT NULL,
 FOREIGN KEY (animal_id) REFERENCES pack_animals (animal_id) 
);

INSERT INTO donkeys (donkey_name, birthday, command, animal_id)
VALUES
('Иа', '2020-01-01', 'Везти!', 2),
('Сет', '2021-06-12', 'Пить!', 2),
('Ниниб', '2022-07-11', 'Стимул!', 2);

--DROP TABLE IF EXISTS horses

CREATE TABLE IF NOT EXISTS horses
(
 horse_id serial PRIMARY KEY,
 horse_name VARCHAR(20)  NOT NULL,
 birthday DATA NOT NULL,
 command VARCHAR(20),
 animal_id int NOT NULL,
 FOREIGN KEY (animal_id) REFERENCES pack_animals (animal_id) 
);

INSERT INTO horses (horse_name, birthday, command, animal_id)
VALUES
('Буцефал', '2021-03-12', 'Захватить!', 1),
('Лошарик', '2022-07-11', 'Жонглировать!', 1),
('Педальный', '2021-06-12', 'Но, пошла!', 1);

--DROP TABLE IF EXISTS camels

CREATE TABLE IF NOT EXISTS camels
(
 camel_id serial PRIMARY KEY,
 camel_name VARCHAR(20)  NOT NULL,
 birthday DATA NOT NULL,
 command VARCHAR(20),
 animal_id int NOT NULL,
 FOREIGN KEY (animal_id) REFERENCES pack_animals (animal_id) 
);

INSERT INTO camels (camel_name, birthday, command, animal_id)
VALUES
('Вася', '2020-01-01', 'Право!', 3),
('Вильма', '2020-11-10', 'Лево!', 3),
('Тоффи', '2020-03-12', 'Стой!', 3);

--DROP TABLE IF EXISTS cats

CREATE TABLE IF NOT EXISTS cats
(
 cat_id serial PRIMARY KEY,
 cat_name VARCHAR(20)  NOT NULL,
 birthday DATA NOT NULL,
 command VARCHAR(20),
 pet_id int NOT NULL,
 FOREIGN KEY (pet_id) REFERENCES pets (pet_id) 
);

INSERT INTO cats (cat_name, birthday, command, pet_id)
VALUES
('Рыжик', '2022-07-11', 'Есть!', 1),
('Барсик', '2022-07-11', 'Спать!', 1),

--DROP TABLE IF EXISTS в dogs

CREATE TABLE IF NOT EXISTS dogs
(
 dog_id serial PRIMARY KEY,
 dog_name VARCHAR(20)  NOT NULL,
 birthday DATA NOT NULL,
 command VARCHAR(20),
 pet_id int NOT NULL,
 FOREIGN KEY (pet_id) REFERENCES pets (pet_id) 
);

INSERT INTO dogs (dog_name, birthday, command, pet_id)
VALUES
('Барбос', '2020-11-10', 'Сидеть!', 2),
('Рекс', '2020-01-01', 'В погоню!', 2),

--DROP TABLE IF EXISTS в hamsters

CREATE TABLE IF NOT EXISTS hamsters
(
 hamster_id serial PRIMARY KEY,
 hamster_name VARCHAR(20)  NOT NULL,
 birthday DATA NOT NULL,
 command VARCHAR(20),
 pet_id int NOT NULL,
 FOREIGN KEY (pet_id) REFERENCES pets (pet_id) 
);

INSERT INTO hamsters (hamster_name, birthday, command, pet_id)
VALUES
('Хомка', '2020-03-12', 'Смирно!', 3),
('Пушок', '2020-01-01', 'Сальто!', 3),

```

</details>

10. Удалив из таблицы верблюдов, т.к. верблюдов решили перевезти в другой
питомник на зимовку. Объединить таблицы лошади, и ослы в одну таблицу.

<details>
  <summary>SQL</summary>

```sql
TRUNCATE TABLE camels

SELECT * FROM horses
UNION
SELECT * FROM donkeys

```

</details>

11. Создать новую таблицу “молодые животные” в которую попадут все
животные старше 1 года, но младше 3 лет и в отдельном столбце с точностью
до месяца подсчитать возраст животных в новой таблице

<details>
  <summary>SQL</summary>

```sql
CREATE TEMPORARY TABLE animals AS 
SELECT *, 'Лошади' as genus FROM horses
UNION SELECT *, 'Ослы' AS genus FROM donkeys
UNION SELECT *, 'Собаки' AS genus FROM dogs
UNION SELECT *, 'Кошки' AS genus FROM cats
UNION SELECT *, 'Хомяки' AS genus FROM hamsters;

CREATE TABLE young_animals AS
SELECT Name, birthday, commands, genus, TIMESTAMPDIFF(MONTH, Birthday, CURDATE()) AS age_in_month
FROM animals WHERE birthday BETWEEN ADDDATE(curdate(), INTERVAL -3 YEAR) AND ADDDATE(CURDATE(), INTERVAL -1 YEAR);

```
</details>

12. Объединить все таблицы в одну, при этом сохраняя поля, указывающие на
прошлую принадлежность к старым таблицам.

<details>
  <summary>SQL</summary>

```sql

SELECT h.name, h.birthday, h.commands, p.animal_name, y.age_in_month 
FROM horses h
LEFT JOIN young_animal ya ON y.name = h.name
LEFT JOIN pack_animals pa ON p.id = h.animal_id
UNION 
SELECT d.name, d.birthday, d.commands, p.animal_name, y.age_in_month 
FROM donkeys d 
LEFT JOIN young_animal y ON ya.name = d.name
LEFT JOIN packed_animals p ON pa.id = d.animal_id
UNION
SELECT c.name, c.birthday, c.commands, ha.pet_name, y.age_in_month 
FROM cats c
LEFT JOIN young_animal y ON y.name = c.name
LEFT JOIN home_animals ha ON ha.id = c.pet_id
UNION
SELECT d.name, d.birthday, d.commands, ha.pet_name, y.age_in_month 
FROM dogs d
LEFT JOIN young_animal y ON y.name = d.name
LEFT JOIN home_animals ha ON ha.id = d.pet_id
UNION
SELECT hm.name, hm.birthday, hm.commands, ha.pet_name, y.age_in_month 
FROM hamsters hm
LEFT JOIN young_animal y ON y.name = hm.name
LEFT JOIN home_animals ha ON ha.id = hm.pet_id;

```

</details>


13. Создать класс с Инкапсуляцией методов и наследованием по диаграмме.
14. Написать программу, имитирующую работу реестра домашних животных.
В программе должен быть реализован следующий функционал:  
14.1 Завести новое животное  
14.2 определять животное в правильный класс  
14.3 увидеть список команд, которое выполняет животное  
14.4 обучить животное новым командам  
14.5 Реализовать навигацию по меню  
15. Создайте класс Счетчик, у которого есть метод add(), увеличивающий̆
значение внутренней̆int переменной̆на 1 при нажатие “Завести новое
животное” Сделайте так, чтобы с объектом такого типа можно было работать в
блоке try-with-resources. Нужно бросить исключение, если работа с объектом
типа счетчик была не в ресурсном try и/или ресурс остался открыт. Значение
считать в ресурсе try, если при заведения животного заполнены все поля.
