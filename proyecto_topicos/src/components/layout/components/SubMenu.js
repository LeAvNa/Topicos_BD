import { Link } from 'react-router-dom';
import React, { useState } from 'react';
import MenuItem from './MenuItem'; // Componente personalizado de menú

function SubMenu({ items = [], onClick }) {
  const [activeMenu, setActiveMenu] = useState(null);

  const handleMenuClick = (label) => {
    setActiveMenu(activeMenu === label ? null : label);
  };

  return (
    items.map((item) => (
      <div
        key={item.etiqueta}
        className={`submenu-item ${item.Hijos?.length > 0 ? 'has-submenu' : ''} ${activeMenu === item.etiqueta ? 'active' : ''}`}
      >
        {item.Hijos?.length > 0 ? (
          <a
            className="submenu-link"
            onClick={(e) => {
              e.preventDefault();
              handleMenuClick(item.etiqueta);
            }}
          >
            <span className="submenu-icon"><i className={`mdi ${item.icon}`}></i></span>
            <span className="submenu-text">{item.etiqueta}</span>
          </a>
        ) : (
          <Link
            to={item.Path}
            className="submenu-link"
            onClick={() => onClick(item.etiqueta)}
          >
            <span className="submenu-icon"><i className={`mdi ${item.icon}`}></i></span>
            <span className="submenu-text">{item.etiqueta}</span>
          </Link>
        )}
        {item.Hijos?.length > 0 && (
          <div className={`submenu-children ${activeMenu === item.etiqueta ? 'show' : 'hide'}`}>
            {item.Hijos.map((hijo) => (
              <MenuItem
                key={hijo.etiqueta}
                path={hijo.Path}
                label={hijo.etiqueta}
                icon={hijo.icon}
                onClick={() => onClick(hijo.etiqueta)}
              />
            ))}
          </div>
        )}
      </div>
    ))
  );
}

export default SubMenu;