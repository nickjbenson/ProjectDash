﻿using System.Collections.Generic;
using UnityEngine;

namespace Leap.Unity.zzOld_Halfedge {

  public static class Primitives {

    public static Halfedge CreatePrimitive(PrimitiveType primitiveType) {
      switch (primitiveType) {
        case PrimitiveType.Tetrahedron:
        default:
          return Primitives.CreateTetrahedron();
      }
    }

    public static Halfedge CreateTetrahedron() {
      Vertex a = new Vertex(-1F, 0F, -1 / Mathf.Sqrt(2));
      Vertex b = new Vertex(1F, 0F, -1 / Mathf.Sqrt(2));
      Vertex c = new Vertex(0F, 1F, 1 / Mathf.Sqrt(2));
      Vertex d = new Vertex(0F, -1F, 1 / Mathf.Sqrt(2));

      Face ABC = new Face();
      //ABC.name = "ABC";
      Halfedge ab = new Halfedge();
      Halfedge bc = new Halfedge();
      Halfedge ca = new Halfedge();
      Vertex ABCa = a, ABCb = b, ABCc = c;
      //ABCa.name = "ABCa"; ABCb.name = "ABCb"; ABCc.name = "ABCc";

      Face ACD = new Face();
      //ACD.name = "ACD";
      Halfedge ac = new Halfedge();
      Halfedge cd = new Halfedge();
      Halfedge da = new Halfedge();
      Vertex ACDa = Vertex.Copy(a), ACDc = Vertex.Copy(c), ACDd = d;
      //ACDa.name = "ACDa"; ACDc.name = "ACDc"; ACDd.name = "ACDd";

      Face ADB = new Face();
      //ADB.name = "ADB";
      Halfedge ad = new Halfedge();
      Halfedge db = new Halfedge();
      Halfedge ba = new Halfedge();
      Vertex ADBa = Vertex.Copy(a), ADBd = Vertex.Copy(d), ADBb = Vertex.Copy(b);
      //ADBa.name = "ADBa"; ADBd.name = "ADBd"; ADBb.name = "ADBb";

      Face BDC = new Face();
      //BDC.name = "BDC";
      Halfedge bd = new Halfedge();
      Halfedge dc = new Halfedge();
      Halfedge cb = new Halfedge();
      Vertex BDCb = Vertex.Copy(b), BDCd = Vertex.Copy(d), BDCc = Vertex.Copy(c);
      //BDCb.name = "BDCb"; BDCd.name = "BDCd"; BDCc.name = "BDCc";

      ABC.halfedge = ab;
      ABCa.halfedge = ca;
      ABCb.halfedge = ab;
      ABCc.halfedge = bc;
      ab.vertex = ABCb;
      ab.face = ABC;
      ab.opposite = ba;
      ab.next = bc;
      ab.prev = ca;
      bc.vertex = ABCc;
      bc.face = ABC;
      bc.opposite = cb;
      bc.next = ca;
      bc.prev = ab;
      ca.vertex = ABCa;
      ca.face = ABC;
      ca.opposite = ac;
      ca.next = ab;
      ca.prev = bc;

      ACD.halfedge = ac;
      ACDa.halfedge = da;
      ACDc.halfedge = ac;
      ACDd.halfedge = cd;
      ac.vertex = ACDc;
      ac.face = ACD;
      ac.opposite = ca;
      ac.next = cd;
      ac.prev = da;
      cd.vertex = ACDd;
      cd.face = ACD;
      cd.opposite = dc;
      cd.next = da;
      cd.prev = ac;
      da.vertex = ACDa;
      da.face = ACD;
      da.opposite = ad;
      da.next = ac;
      da.prev = cd;

      ADB.halfedge = ad;
      ADBa.halfedge = ba;
      ADBd.halfedge = ad;
      ADBb.halfedge = db;
      ad.vertex = ADBd;
      ad.face = ADB;
      ad.opposite = da;
      ad.next = db;
      ad.prev = ba;
      db.vertex = ADBb;
      db.face = ADB;
      db.opposite = bd;
      db.next = ba;
      db.prev = ad;
      ba.vertex = ADBa;
      ba.face = ADB;
      ba.opposite = ab;
      ba.next = ad;
      ba.prev = db;

      BDC.halfedge = bd;
      BDCb.halfedge = cb;
      BDCd.halfedge = bd;
      BDCc.halfedge = dc;
      bd.vertex = BDCd;
      bd.face = BDC;
      bd.opposite = db;
      bd.next = dc;
      bd.prev = cb;
      dc.vertex = BDCc;
      dc.face = BDC;
      dc.opposite = cd;
      dc.next = cb;
      dc.prev = bd;
      cb.vertex = BDCb;
      cb.face = BDC;
      cb.opposite = bc;
      cb.next = bd;
      cb.prev = dc;

      return ABC.halfedge;
    }

  }

}