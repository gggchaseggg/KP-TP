import React from 'react';
import style from "./Profile.module.scss"
import {useUserByLogin} from "../../queries/User/userQueries";
import {useAppSelector} from "../../redux/hooks";
import {Link, useParams} from "react-router-dom";
import PATHS from "../../data/paths";
import clsx from "clsx";
import toRUroles from "../../data/roles";

const Profile = () => {

  const user = useAppSelector(state => state.user);
  const {login} = useParams()
  const {data: student} = useUserByLogin(login as string);
  const isShow = login === user.login

  return (
    <div className={style.wrapper}>
      <h1>Мой профиль</h1>
      <div className={style.main}>
        <div className={style.leftBlock}>
          <img src="/img/Profile/notIcon.webp" alt="лого" className={style.logo}/>
          <h3 className={style.name}>{student?.surname} {student?.name}</h3>
          <p className={style.email}>{student?.email}</p>
          <div className={style.score}>
            <div className={style.score__left}>
              <p className={style.score__title}>Очки</p>
              <p className={style.score__count}>573</p>
            </div>
            <Link to={PATHS.SCORE_INFO} className={style.score__link}>Подробнее</Link>
          </div>
          {isShow && <div className={style.pages}>
              <input type="radio" name="pages" id={style.desktop} className={style.pages__radio} defaultChecked={true}/>
              <label htmlFor={style.desktop} className={style.pages__label} id={style.desktop_label}>Рабочий
                  стол</label>
              <input type="radio" name="pages" id={style.course} className={style.pages__radio}/>
              <label htmlFor={style.course} className={style.pages__label} id={style.course_label}>Курсы</label>
              <input type="radio" name="pages" id={style.settings} className={style.pages__radio}/>
              <label htmlFor={style.settings} className={style.pages__label} id={style.settings_label}>Настройки</label>
          </div>}
        </div>
        <div className={style.rightBlock}>
          <div id={clsx(style.desktopTab, !isShow ? style.tabActive : "")}>
            <p className={style.tab__title}>Общие сведения</p>
            <div className={style.tab__block}>
              <h4 className={style.desktopTab__name}>{student?.surname} {student?.name} {student?.patronomic}</h4>
              <hr/>
              <h6>Основная информация</h6>
              {student && <table>
                <tbody>
                <tr>
                  <td className={style.table__opr}>Група:</td>
                  <td className={style.table__znach}>{student.group}</td>
                </tr>
                <tr>
                  <td className={style.table__opr}>Кафедра:</td>
                  <td className={style.table__znach}>{student.departament}</td>
                </tr>
                <tr>
                  <td className={style.table__opr}>Почта:</td>
                  <td className={style.table__znach}>{student.email}</td>
                </tr>
                <tr>
                  <td className={style.table__opr}>Роль:</td>
                  <td className={style.table__znach}>{toRUroles(student.role)}</td>
                </tr>
                </tbody>
              </table>}
            </div>
          </div>
          {isShow && <>
              <div id={style.courseTab}>
                  курсы
              </div>
              <div id={style.settingsTab}>
                  настройки
              </div>
          </>}
        </div>
      </div>
    </div>
  );
};

export default Profile;