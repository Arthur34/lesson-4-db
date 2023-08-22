--***************************************************************
-- создаем БД

create database otus;


--***************************************************************
-- создание таблиц

-- курсы
--drop table "courses";
create table "courses"
(
	"id" serial primary key,
	"name" varchar(255) unique not null,
	"price" money null
);

-- темы курсов
--drop table "topics";
create table "topics"
(
	"id" serial primary key,
	"name" varchar(255) not null,
	"course_id" int references "courses"("id") not null
);

-- учащиеся
--drop table "learners";
create table "learners"
(
	"id" serial primary key,
	"name" varchar(255) not null
);

-- связь учащихся и курсов
--drop table "learners_courses";
create table "learners_courses"
(
	"id" serial primary key,
	"learner_id" int references "learners"("id") not null,
	"course_id" int references "courses"("id") not null
);

-- баллы за прошедшую тему для учащегося
--drop table "learnerscourses_topics";
create table "learnerscourses_topics"
(
	"id" serial primary key,
	"learner_course_id" int references "learners_courses"("id") not null,
	"topic_id" int references "topics"("id") not null,
	"points" int null		-- баллы
);


--***************************************************************
-- наполняем таблицы данными

-- курсы
insert into "courses"("name", "price")
values	('Системный аналитик и бизнес-аналитик', 136000),	--1
		('Углубленное изучение языка Java', 200000),		--2
		('C++ Developer', 150000);							--3
--select * from "courses";

-- темы курсов
insert into "topics"("name", "course_id")
values	('Введение в разработку ПО', 1),		--1
		('Работа с требованиями', 1),			--2
		('Визуализация требований', 1),			--3
		('Основы языка Java', 2),				--4
		('Операторы и структуры ветвления', 2),	--5
		('Введение в язык C++', 3),				--6
		('Классы и структуры', 3);				--7
--select * from "topics";
		
-- учащиеся
insert into "learners"("name")
values	('Ермолов Артём Маркович'),			--1
		('Седова София Дмитриевна'),		--2
		('Третьяков Максим Русланович'),	--3
		('Кожевников Никита Даниилович'),	--4
		('Чернова Дарья Львовна');			--5
--select * from "learners";

-- связь учащихся с курсами
insert into "learners_courses"("learner_id", "course_id")
values	(1, 1), --1
		(2, 1), --2
		(3, 1), --3
		(4, 2), --4
		(5, 2), --5
		(5, 3); --6
/*
select lc.*, l."name" as "learner_name", c."name" as "course_name"
from "learners_courses" lc
join "learners" l on lc."learner_id"=l."id"
join "courses" c on lc."course_id"=c."id";
*/

-- баллы за прошедшую тему для учащегося
insert into "learnerscourses_topics"("learner_course_id", "topic_id", "points")
values	(1, 3, 10),
		(2, 2, 15),
		(2, 1, 5),
		(3, 2, 8),
		(3, 3, 14),
		(4, 4, null),
		(5, 5, 0),
		(6, 6, 22),
		(6, 7, 4),
		(5, 4, 13);
/*
select lct.*, l."name" as "learner_name", c."name" as "course_name", t."name" as "topic_name", tc."name" as "topic_course_name"
from "learnerscourses_topics" lct
join "learners_courses" lc on lct."learner_course_id"=lc."id"
join "learners" l on lc."learner_id"=l."id"
join "courses" c on lc."course_id"=c."id"
join "topics" t on lct."topic_id"=t."id"
join "courses" tc on t."course_id"=tc."id";
*/
