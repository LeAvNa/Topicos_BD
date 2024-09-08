import React, { useState, useEffect } from 'react';
import { useLocation, Link } from 'react-router-dom';
import { EstructuraMenu } from '../../constants/EstructuraMenu';
import SubMenu from './components/SubMenu';
import "./Sidebar.css";

function Sidebar() {
  const location = useLocation();
  const [activeMenu, setActiveMenu] = useState('Inicio');

  useEffect(() => {
    const currentMenu = Object.values(EstructuraMenu)
      .flatMap((cat) => cat.items)
      .find((item) => item.Path === location.pathname)?.etiqueta
      || localStorage.getItem('activeMenu')
      || 'Inicio';

    setActiveMenu(currentMenu);
    localStorage.setItem('activeMenu', currentMenu);
  }, [location]);

  const handleMenuClick = (menuText) => {
    setActiveMenu(menuText);
    localStorage.setItem('activeMenu', menuText);
  };

  return (
    <div id="sidebar" className="app-sidebar">
      <div className="app-sidebar-header">
        <Link className="brand-logo" to="/" onClick={() => handleMenuClick('Inicio')}>
          <h1>Topicos</h1>
        </Link>
      </div>
      <div className="menu">
        {Object.keys(EstructuraMenu).map((categoryKey) => {
          const category = EstructuraMenu[categoryKey];
          return (
            <React.Fragment key={categoryKey}>
              <div className="menu-header">
                <span className="menu-text">{category.etiqueta}</span>
              </div>
              <SubMenu items={category.items || []} onClick={handleMenuClick} />
              <div className="menu-divider"></div>
            </React.Fragment>
          );
        })}
      </div>
      <button className="app-sidebar-mobile-backdrop" data-dismiss="sidebar-mobile"></button>
    </div>
  );
}

export default Sidebar;