﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

interface IDamagable {
    void ReceiveDamage(float damageDone);
    void Die();
}
