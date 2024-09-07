import React from 'react';
import MenuItem from './MenuItem';

function SubMenu({ items = [], activeMenu, onClick }) {
  return (
    items.map((item) =>
      <div
        key={item.etiqueta}
        className={`menu-item ${item.Hijos?.length > 0 ? 'has-sub' : ''} ${activeMenu === item.etiqueta ? 'active' : ''}`}
      >
        <a
          className="menu-link expand"
          href={item.Hijos ? "#." : item.Path}
          onClick={onClick}
        >
          <span className="menu-icon">
            <i className={`mdi ${item.icon}`}></i>
          </span>
          <span className="menu-text">{item.etiqueta}</span>
          {item.Hijos?.length > 0 && <span className="menu-caret"><b className="caret"></b></span>}
        </a>
        {item.Hijos?.length > 0 && (
          <div className="menu-submenu" style={{ display: `${activeMenu === item.etiqueta ? 'block' : 'none'}` }}>
            {item.Hijos.map(hijo => (
              <MenuItem
                key={hijo.etiqueta} // Ensure each MenuItem has a unique key
                path={hijo.Path}
                label={hijo.etiqueta}
                icon={hijo.icon}
                isActive={activeMenu === hijo.etiqueta}
                onClick={onClick}
              />
            ))}
          </div>
        )}
      </div>
    )
  );
}

export default SubMenu;
