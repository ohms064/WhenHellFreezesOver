using UnityEngine;
using System.Collections;

public enum GroundedState {
    GROUNDED,
    ON_AIR,
    SEMI_GROUNDED
}

public enum GrabStatus {
    GRABING_OBJECT,
    ROTATING_OBJECT,
    HANDS_FREE
}