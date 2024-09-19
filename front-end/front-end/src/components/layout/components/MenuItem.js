import React from 'react';
import { Link } from 'react-router-dom';

function MenuItem({ path, label, icon, onClick }) {
  return (
    <div className="menu-item">
      <Link to={path} className="menu-link" onClick={() => onClick && onClick(label)}>
        <span className="menu-icon"><i className={`mdi ${icon}`}></i></span>
        <span className="menu-text">{label}</span>
      </Link>
    </div>
  );
}

export default MenuItem;