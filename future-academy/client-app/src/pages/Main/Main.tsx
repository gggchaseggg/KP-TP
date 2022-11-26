import React from "react";
import style from "./Main.module.scss";
import clsx from "clsx";
import { MONTHS } from "../../data/month";
import { Link } from "react-router-dom";
import PATHS from "../../data/paths";

const Main = () => {
  const openDoorDate = new Date(2022, 10, 25);
  const programsCount = 101;
  const teachersCount = 82;
  const graduatesCount = 14795;
  //TODO:GET даты дня открытых дверей
  //TODO:GET цифр количества крутости

    const func = () => {
        fetch("weatherforecast").then(response => response.json()).then(data => console.log(data))
    }

  return (
      <div>
          <button onClick={func }>fgdsfdfsd</button>
      <img
        src="/img/Main/mainHeader.png"
        alt="картинка"
        width={"100%"}
        id={style.headerImage}
      />
      <div className={style.info}>
        <p>Актуальные знания от признанных практикующих специалистов</p>
        <div className={style.numbers}>
          <span>{programsCount}</span>
          <span>{teachersCount}</span>
          <span>{graduatesCount}</span>
        </div>
      </div>
      <div className={style.links}>
        <Link to={PATHS.OPEN_DOORS}>
          <div className={clsx(style.openDoors, "orangeCard")}>
            <div className={style.openDoors__date}>
              <p className={style.openDoors__day}>{openDoorDate.getDate()}</p>
              <p className={style.openDoors__month}>
                {MONTHS[openDoorDate.getMonth()]}
              </p>
            </div>
            <div className={style.openDoors__text}>
              <h3>День открытых дверей</h3>
              <p>
                Приглашаем всех желающих на бесплатную экскурсию в мир
                востребованных профессий и полезных навыков
              </p>
            </div>
            <div className={style.openDoors__button}>Записаться</div>
          </div>
        </Link>
        <div className={style.linksDown}>
          <Link to={PATHS.PROGRAMS}>
            <div className={clsx(style.programs, "blueCard")}>
              <img src="/img/Main/programsMonitor.png" alt="монитор" />
              <h4>Программы обучения</h4>
              <p>
                В списке наших курсов вы сможете найти профессию и занятие по
                душе, изучить новое и получить практические знания, которые
                помогут получить работу мечты.
              </p>
              <div className={style.programs__button}>Подробнее</div>
            </div>
          </Link>
          <div className={style.other}>
            <Link to={PATHS.NEWS}>
              <div className={clsx(style.news, "greenCard")}>
                <img src="/img/Main/news.png" alt="новости" />
                <h3>Новости</h3>
              </div>
            </Link>
            <Link to={PATHS.WORLD_IT}>
              <div className={clsx(style.worldIT, "pinkCard")}>
                <img src="/img/Main/circleWorld.png" alt="мирИТ" />
                <h3>Мир IT</h3>
              </div>
            </Link>
            <Link to={PATHS.TEST}>
              <div className={clsx(style.test, "yellowCard")}>
                <img src="/img/Main/testImage.png" alt="тест" />
                <div className={style.test__text}>
                  <h3>Попробуй!</h3>
                  <p>
                    Пройдите тест и узнайте свои способности в сфере
                    информационных технологий
                  </p>
                </div>
              </div>
            </Link>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Main;
