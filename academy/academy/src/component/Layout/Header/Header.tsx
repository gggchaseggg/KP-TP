import React from "react";
import style from "./Header.module.scss";
import MenuIcon from "../../SvgIcons/MenuIcon";
import CityIcon from "../../SvgIcons/CityIcon";
import SignIcon from "../../SvgIcons/SignIcon";
import clsx from "clsx";
import ProfileIcon from "../../SvgIcons/ProfileIcon";

const Header = () => {
  return (
    <div className={style.wrapper}>
      <nav className={style.navigation}>
        <ul className={style.navList}>
          <li className={style.navItem}>
            <img src="/img/Layout/logo.png" alt="лого" />
          </li>
          <li className={style.navItem}>
            <MenuIcon className={style.icon} />
            <span>Все специальности</span>
          </li>
          <li className={style.navItem}>Мероприятия</li>
          <li className={style.navItem}>Новости</li>
          <li className={style.navItem}>Карьера</li>
          <li className={style.navItem}>
            <CityIcon className={style.icon} />
            <span className={style.city}>Нижний новгород</span>
            <SignIcon className={clsx(style.icon, style.signIcon)} />
          </li>
          <li className={style.navItem}>
            <a href="tel:89190127950" className={style.tel}>
              8 919 012-79-50
            </a>
          </li>
          <li className={style.navItem}>
            <ProfileIcon className={style.icon} />
            <span>Войти</span>
          </li>
        </ul>
      </nav>
    </div>
  );
};

export default Header;
