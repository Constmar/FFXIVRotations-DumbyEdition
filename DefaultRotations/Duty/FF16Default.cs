﻿using RotationSolver.Basic.Record;
using RotationSolver.Basic.Rotations.Duties;

namespace DefaultRotations.Duty;

[Rotation("FF16 Default", CombatType.PvE)]

public class FF16Default : FF16Rotation
{
    public override bool EmergencyAbility(IAction nextGCD, out IAction? act)
    {
        if (GetRecordData<VfxNewData>(1.2f, 3).Any(d => d.Path == "vfx/common/eff/kaihi_stlp_c1v.avfx"))
        {
            if (DodgePvE_33997.CanUse(out act, skipClippingCheck: true)) return true;
        }

        return base.EmergencyAbility(nextGCD, out act);
    }

    public override bool AttackAbility(out IAction? act)
    {
        if (PrecisionStrikePvE.CanUse(out act, skipAoeCheck: true)) return true;
        if (RisingFlamesPvE.CanUse(out act, skipAoeCheck: true)) return true;

        return base.AttackAbility(out act);
    }
}
