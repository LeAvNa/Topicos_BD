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
        <a
          className="submenu-link"
          href={item.Hijos ? "#." : item.Path}
          onClick={(e) => {
            if (item.Hijos?.length > 0) {
              e.preventDefault();
              handleMenuClick(item.etiqueta);
            } else {
              onClick(item.etiqueta);
            }
          }}
        >
          <span className="submenu-icon"><i className={`mdi ${item.icon}`}></i></span>
          <span className="submenu-text">{item.etiqueta}</span>
        </a>
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