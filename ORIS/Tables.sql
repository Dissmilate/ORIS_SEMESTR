CREATE TABLE Genres (
    genre_id INT IDENTITY(1,1) PRIMARY KEY,
    genre_name NVARCHAR(100) NOT NULL
);

INSERT INTO Genres (genre_name) VALUES ('Комедия');
INSERT INTO Genres (genre_name) VALUES ('Драма');
INSERT INTO Genres (genre_name) VALUES ('Экшн');
INSERT INTO Genres (genre_name) VALUES ('Фантастика');
INSERT INTO Genres (genre_name) VALUES ('Ужасы');
INSERT INTO Genres (genre_name) VALUES ('Мелодрама');
INSERT INTO Genres (genre_name) VALUES ('Приключения');
INSERT INTO Genres (genre_name) VALUES ('Триллер');


CREATE TABLE Movie_Genres (
    movie_id INT NOT NULL,
    genre_id INT NOT NULL,
    PRIMARY KEY (movie_id, genre_id),
    FOREIGN KEY (movie_id) REFERENCES Movies(movie_id),
    FOREIGN KEY (genre_id) REFERENCES Genres(genre_id)
);

INSERT INTO Movie_Genres (movie_id, genre_id) VALUES (1, 1);  
INSERT INTO Movie_Genres (movie_id, genre_id) VALUES (1, 3); 
INSERT INTO Movie_Genres (movie_id, genre_id) VALUES (2, 3);  
INSERT INTO Movie_Genres (movie_id, genre_id) VALUES (2, 4);  
INSERT INTO Movie_Genres (movie_id, genre_id) VALUES (3, 1);  
INSERT INTO Movie_Genres (movie_id, genre_id) VALUES (3, 3); 
INSERT INTO Movie_Genres (movie_id, genre_id) VALUES (3, 4);  
INSERT INTO Movie_Genres (movie_id, genre_id) VALUES (4, 3); 
INSERT INTO Movie_Genres (movie_id, genre_id) VALUES (4, 5);
INSERT INTO Movie_Genres (movie_id, genre_id) VALUES (5, 2); 
INSERT INTO Movie_Genres (movie_id, genre_id) VALUES (6, 5);  
INSERT INTO Movie_Genres (movie_id, genre_id) VALUES (7, 2);  

CREATE TABLE Movies (
    MovieID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(255),
    Description NVARCHAR(1000),
    IMDbRating DECIMAL(3,1),
    IMDbVotes INT,
    ReleaseDate VARCHAR(50),
    Country NVARCHAR(100),
    Director NVARCHAR(255),
    Genre NVARCHAR(255),
    Quality VARCHAR(50),
    AgeRating VARCHAR(10),
    Duration INT,
    PosterUrl VARCHAR(255),
    GenreId INT,
    Type NVARCHAR(50)
);

INSERT INTO Movies (Title, Description, IMDbRating, IMDbVotes, ReleaseDate, Country, Director, Genre, Quality, AgeRating, Duration, PosterUrl, GenreId, Type)
VALUES
('Карибская тайна', 'Майор в отставке Джеффри Пэлгрейв, пишущий мемуары на карибском курорте, случайно выясняет, что один из проживающих в отеле является женоубийцей (по образу и подобию Синей Бороды). Но прежде, чем показать мисс Джейн Марпл его фотографию, майор становится жертвой вроде бы случайной передозировки алкоголя и препарата для снижения артериального давления. После того, как фотоснимок загадочно исчезает, и выясняется, что препарат принадлежит другому постояльцу отеля, мисс Марпл приходит к выводу: серийный убийца вновь взялся за старое. И, что хуже всего, убийства будут продолжаться. За помощью в разгадке преступления она обращается к пожилому, грубоватому бизнесмену мистеру Рефилу.', 6.3, 864, '1983-10-22', 'США', 'Роберт Майкл Льюис', 'Детектив', '720p', '0+', 1, '', 6, 'Фильм'),
('Побег из лагеря МакКензи', 'Заключительный этап Второй мировой войны. В лагере для немецких военнопленных в Северной Англии происходит бунт и британское командование посылает в лагерь ирландского капитана Кейта в надежде на то,', 6.0, 123, '1983-10-22', 'США', 'Лэмонт Джонсон', 'Боевик', '1080p', '16+', 5, '', 7, 'Фильм'),
('Сверкающий цианид', 'Семь человек собираются в ресторане на торжественный ужин по случаю годовщины свадьбы четы Бартонов. Розмари Бартон умирает прямо за столом от отравления цианистым калием. Полиция считает одной из вероятных причин смерти самоубийство, вызванное депрессией. Позже ее муж Джордж Бартон получает анонимное письмо, в котором утверждается, что Розмари была убита. Пытаясь самостоятельно разрешить загадку смерти жены, он приглашает в тот же ресторан всех участников того злополучного ужина. Актрису, удивительно похожую на его покойную жену, он просит сыграть ее роль. Однако актриса так и не приходит…', 5.9, 875, '1999-11-22', 'США', 'Роберт Майкл Льюис', 'Детектив', '720p', '18+', 7, '', 5, 'Фильм'),
('Цикада', 'Четверо друзей объединяются, чтобы защитить Лос-Анджелес от роя гигантских кровожадных цикад.', 8.3, 397, '2005-11-14', 'США', 'Дэвид Уиллис', 'Комедия', '720p', '12+', 6, '', 4, 'Сериал'),
('Реминисценция: начало', 'Есть миры, есть люди и есть Другие. Но есть только одно Время, которое является границей между мирами. Что, если Время сломается?', 4.7, 392, '1990-10-15', 'Испания', '', 'Ужасы', '720p', '0+', 8, '', 5, 'Сериал'),
('Первая любовь', 'Режиссёрский дебют Эрика Кота, в котором рассказываются истории о первой любви, до и после. В первой, Такеши Канеширо в роли сборщика мусора влюбляется в девушку, которая страдает лунатизмом. Во второй истории рассказывается о владельце продуктовой лавки, голова которого забита одним - вернулась его старая возлюбленная, которую он бросил 10 лет назад.', 3.2, 267, '1983-10-22', 'США', 'Рэймонд Мартино', 'Драма', '720p', '0+', 2, '', 6, 'Мультфильм'),
('До крайнего предела', 'Пришло время последней смерти, и погибнешь либо ты сам, либо тот, кто тебя обманул. Фрэнк Да Винчи и Колетт Дюбуа ищут того, кто приказал их убить…', 7.4, 346, '1983-10-22', 'Франция', 'Бернардо Бертолуччи', 'Боевик', '720p', '0+', 2, '', 3, 'Аниме'),
('Перед революцией', 'Наслушавшись рассуждений суицидально настроенного приятеля Агостино о необходимости революционного слома, Фабрицио разрывает отношения с навязанной ему буржуазным семейством невестой и в качестве радикального жеста вступает в связь со своевольной сестрой матери.', 5.7, 654, '1983-10-22', 'США', 'Бибан Кидрон', 'Драма', '1080p', '18+', 1, '', 8, 'Мультфильм'),
('Второе дыхание', 'На похоронах мужа Перл, еврейская мать двух разведенных и враждующих дочерей, встречает старого итальянского друга своего мужа, чьи советы много лет назад остановили мужа от ухода из дома. В течение 23 лет он тайно любил Перл...', 4.6, 117, '1983-10-22', 'США', 'Роберт Марковиц', 'Комедия', '720p', '18+', 5, '', 5, 'Фильм'),
('Смерть в горах', 'Подлинная история одного из самых драматических восхождений на Эверест в мае 1996 года, когда на высочайшую вершину мира пытались подняться сразу две группы альпинистов, возглавляемые Скоттом Фишером и Робом Холлом. Скотт и Роб вели богатых клиентов, заплативших немыслимые деньги за то, чтобы почувствовать себя настоящими альпинистами, хотя никто из них не имел ни малейшего представления, что такое горы. Проводники были вынуждены выполнять все прихоти и капризы своих подопечных, и это привело к тому, что, несмотря на весь свой опыт, Скотт и Роб начинают совершать одну ошибку за другой. В результате амбиции, бессердечие, невезение и плохая погода загнали обе группы в смертельную ловушку…', 5.0, 228, '1983-10-22', 'США', 'Марк Гриффитс', 'Приключения', '720p', '16+', 6, '', 6, 'Фильм'),
('Наш дом', 'Бездомная женщина спасает жизнь вдове из Беверли-Хиллз, и в знак благодарности состоятельная женщина открывает двери своего дома не только перед ней, но и перед её лишенными крова друзьями. Возражения со стороны членов семьи и знакомых вдовы приводят к судебному разбирательству, в результате которого она может потерять всё, за что боролась.', 7.5, 268, '1983-10-22', 'США', 'Лау Ка-Люн', 'Драма', '720p', '16+', 7, '', 7, 'Фильм'),
('Пьяная обезьяна', 'Виртуоз стиля пьяной обезьяны Ман Биу становится жертвой заговора своего брата Пао, предавшего его ради денег за контрабанду опиума. Ману Биу чудом удается сбежать от наймитов брата, и с тех пор он находит приют в провинциальной глубинке, взяв на воспитание бездомную девушку. Несколько лет спустя Мана находят два паренька, мечтающие изучить стиль пьяной обезьяны, но вслед за ними на Мана выходит и его брат.', 6.2, 337, '1983-10-22', 'США', 'Корбин Бернсен', 'Боевик', '1080p', '18+', 8, '', 5, 'Фильм'),
('3-х дневный тест', 'Семьянин и бухгалтер Мартин Тейлор полностью потерял связь со своей семьей. Он не имеет ни малейшего представления о том, кто друзья его дочери-подростка, почему его сын общается только с электронными гаджетами, или почему его младший ребенок только тем и занимается, что смотрит телевизор. Будучи твердо убежденным в необходимости объединения семьи, Мартин к удивлению своих домочадцев проводит небольшой эксперимент, — он блокирует их в собственном доме абсолютно без каких-либо контактов с внешним миром…', 7.1, 210, '1983-10-22', 'Турция', 'Иржи Секвенс', 'Комедия', '1080p', '0+', 6, '', 4, 'Фильм'),
('Загадка чёрного короля', 'У ручья найден труп инкассатора Крала, переносившего в день смерти из банка на фабрику 62 тысячи. Деньги пропали. В ходе расследования советник Вацатко с помощниками находят всё новых и новых подозреваемых, но обнаруживают полное отсутствие улик.', 8.3, 167, '1983-10-22', 'США', 'Найджел Дик', 'Детектив', '720p', '0+', 5, '', 8, 'Фильм'),
('Смертельная связь', 'Работая в отделе по расследованию убийств, детектив Диксон встречается с бессмысленным насилием гораздо чаще, чем ему хотелось бы. Он преследует убийц и собирает трупы их жертв. Последнее дело Диксона не представляет собой ничего нового — изнасилование и убийство двух молодых женщин в местном мотеле, неоплаченный счет за разговор по секс — телефону и целая куча необъяснимых загадок. Расследование заходит в тупик, но на помощь детективу приходит журналистка Кэтрин, красота и обаяние, которой совершенно очаровывают Диксона. У Кэтрин имеется информация о похожих убийствах, совершенных за последнее время по всей стране. С ее помощью Диксон выслеживает таинственного убийцу — обаятельного незнакомца, обольщающего, а затем убивающего молодых женщин, и начинается смертельно опасный поединок с преступником.', 8.9, 926, '1983-10-22', 'США', 'Клод Виталь', 'Триллер', '720p', '18+', 3, '', 2, 'Фильм'),
('Если она скажет «да»... я не откажусь', 'Когда неуклюжего Марселя рано утром выгоняет из квартиры его девушка, без обуви и брюк, с чашкой кофе в руке, его первым побуждением становится самоубийство. Поразмыслив, он решает посетить свой любимый отель. Однако его обычный номер занят репортером Кэтрин. Чтобы произвести на нее впечатление, он рассказывает ей историю о том, что владеет компанией, в которой работает. Она пишет о нем рассказ. Сможет ли он завоевать ее сердце, несмотря на эту ложь?', 9.1, 254, '1983-10-22', 'Великобритания', 'Джон Флинн', 'Драма', '1080p', '18+', 2, '', 9, 'Мультфильм'),
('Тронутый', 'Пара влюбленных «узников» психушки планируют побег в поисках нормальной жизни.', 5.6, 690, '1983-10-22', 'США', 'Дзюнъити Ямамото', 'Драма', '720p', '16+', 2, '', 3, 'Аниме'),
('В любом случае я влюблюсь в тебя', '1 июля 2020 года старшекласснице Мидзухо исполнилось 17 лет, и это был её худший день рождения. Сэмпай, который её нравится, не проявляет к ней интереса, а отец вообще забыл про праздник. К тому же из-за разгула непонятной инфекции отменили соревнование секции плавания и школьную поездку. Всё меняется, когда друг детства внезапно приглашает её на свидание.', 3.1, 555, '1983-10-22', 'США', 'Этьен Хуэт', 'Аниме', '720p', '0+', 2, '', 2, 'Аниме'),
('Любовь в Бангкоке / Любовь с первого взгляда в Бангкоке', '32-летняя Лаура Брунель - страстная и амбициозная архитектор из прекрасного города Бангкок. Ее бюро участвует в тендере на строительство нового роскошного объекта – футуристического торгового центра. У Лауры есть неделя, чтобы погрузиться в город и доработать планы этого ультрасовременного торгового рая. На месте Лора попадает под чары таинственного Марка Лавуазье.', 1.9, 316, '1983-10-22', 'США', '', 'Драма', '720p', '0+', 3, '', 9, 'Мультфильм'),
('1', '1\n1\n1\n', 1.0, 1, '1111-11-11', '1', '1', '1', '1', '1', 1, '', 1, '1');

CREATE TABLE Users (
    id INT IDENTITY(1,1) PRIMARY KEY, -- Автоинкрементируемый идентификатор
    name NVARCHAR(50),                 -- Имя пользователя
    email NVARCHAR(100),               -- Электронная почта пользователя
    ifBlocked BIT,                     -- Флаг блокировки пользователя
    password NVARCHAR(100)             -- Пароль пользователя
);

INSERT INTO Users (name, email, ifBlocked, password) VALUES
('Amerigo', 'amcminn0@deliciousdays.com', 0, '123'),
('Noella', 'ndarrington1@google.fr', 0, '123412'),
('Phaidra', 'pware2@1688.com', 0, '513461466'),
('Daffi', 'dveale3@istockphoto.com', 0, '34363613464'),
('Guthrie', 'glondors4@auda.org.au', 1, '6'),
('Shea', 'sskentelbery5@abc.net.au', 0, '13464'),
('Delano', 'deverson6@bloglines.com', 0, '6134'),
('Katee', 'khaslewood7@fc2.com', 0, '64'),
('Engracia', 'etaylo8@imdb.com', 0, '6146'),
('Hastings', 'hcranmor9@bravesites.com', 0, '34'),
('Kalila', 'kshalla@nasa.gov', 0, '475'),
('Aube', 'amenendezb@squidoo.com', 0, '75'),
('Bidget', 'bbirtchnellc@typepad.com', 1, '68'),
('Gearard', 'ggregand@mit.edu', 0, '56'),
('Griffin', 'gmcindrewe@tripadvisor.com', 0, '856'),
('Corenda', 'cegintonf@examiner.com', 0, '856486'),
('Ardith', 'adearesg@creativecommons.org', 0, '883536'),
('Remus', 'rgummeryh@creativecommons.org', 0, '47'),
('Audi', 'achurchmani@ucsd.edu', 0, '64'),
('Cairistiona', 'csinfieldj@amazonaws.com', 0, '62365'),
('Ernest', 'eenstenk@china.com.cn', 0, '4787'),
('Terri', 'tkahanl@i2i.jp', 0, '64537'),
('Avrit', 'awolpertm@flickr.com', 0, '4643'),
('Konstantin', 'kwhalleyn@elegantthemes.com', 0, '564576'),
('Mamie', 'mbrendisho@pinterest.com', 0, '58769'),
('Marguerite', 'msaggp@ft.com', 1, '6857'),
('Jedediah', 'jbowdonq@comsenz.com', 0, '4636'),
('Kessiah', 'kstockler@google.com', 0, '4567564785'),
('Dukey', 'dsweetmans@hhs.gov', 0, '7987'),
('Alidia', 'abubeart@apache.org', 0, '6857646'),
('Luce', 'llacroceu@vistaprint.com', 0, '546'),
('Frants', 'frickwoodv@chron.com', 0, '6478'),
('Shadow', 'smickaw@wikipedia.org', 0, '96'),
('Constantine', 'cjewesx@sun.com', 0, '54'),
('Bethina', 'bhattersleyy@wiley.com', 0, '678'),
('Carney', 'cpuffettz@blinklist.com', 0, '765'),
('Frank', 'fseide10@i2i.jp', 0, '43'),
('Ignaz', 'ivasyukov11@pbs.org', 0, '456'),
('Erminie', 'estraniero12@npr.org', 0, '78'),
('Vally', 'vdilliway13@usatoday.com', 0, '765'),
('Teresita', 'tfell14@rambler.ru', 0, '4'),
('Carey', 'cpetry15@yellowbook.com', 0, '56'),
('Farris', 'fquigley16@unesco.org', 0, '789'),
('Sandra', 'sgenike17@list-manage.com', 0, '0'),
('Kile', 'kdoyle18@behance.net', 0, '87'),
('Chico', 'ccurd19@prweb.com', 0, '65'),
('Worthington', 'wpaddell1a@scribd.com', 0, '4'),
('Myrilla', 'mancliffe1b@state.tx.us', 0, '3'),
('Rosalind', 'rdarrigone1c@kickstarter.com', 0, '4'),
('Bernetta', 'bgladdolph1d@redcross.org', 0, '5445524'),
('Earle', 'eveldman1e@chicagotribune.com', 0, '45'),
('Blanche', 'bmoyle1f@amazon.com', 0, '64'),
('Charlotte', 'cantunes1g@timesonline.co.uk', 0, '654'),
('Lavinia', 'lpretor1h@bloglovin.com', 0, '642'),
('Jesse', 'jgildea1i@virginia.edu', 0, '64'),
('Arliene', 'aorafferty1j@indiatimes.com', 0, '642'),
('Emmerich', 'ebodham1k@smh.com.au', 0, '6542'),
('Ly', 'lorhtmann1l@paypal.com', 0, '654'),
('Marcellus', 'malbany1m@wunderground.com', 0, '642'),
('Alex', 'avella1n@about.com', 1, '26546'),
('Miltie', 'mconisbee1o@fastcompany.com', 0, '54'),
('Gregory', 'grapley1p@storify.com', 0, '652'),
('Sheeree', 'sproudlove1q@4shared.com', 0, '54'),
('Karleen', 'kkuhnwald1r@google.com.hk', 0, '654'),
('Calvin', 'ccunningham1s@statcounter.com', 1, '6245'),
('Leslie', 'lminette1t@cdbaby.com', 0, '645'),
('Blithe', 'bsanders1u@globo.com', 0, '2654'),
('Chrissy', 'chayer1v@ezinearticles.com', 0, '6426'),
('Loutitia', 'laiton1w@usatoday.com', 0, '546'),
('Robin', 'rscarrott1x@twitpic.com', 0, '546'),
('Emir', 'emirhann205@yandex.ru', 0, '123'),
('Emir', 'qwe@mail.ru', 0, '123');
