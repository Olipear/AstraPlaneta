//Maya ASCII 2015 scene
//Name: Door_L_Template.ma
//Last modified: Sat, Jan 02, 2016 08:14:57 PM
//Codeset: 1252
requires maya "2015";
requires -dataType "byteArray" "Mayatomr" "2015.0 - 3.12.1.16 ";
currentUnit -l centimeter -a degree -t pal;
fileInfo "application" "maya";
fileInfo "product" "Maya 2015";
fileInfo "version" "2015";
fileInfo "cutIdentifier" "201405190330-916664";
fileInfo "osv" "Microsoft Windows 8 Home Premium Edition, 64-bit  (Build 9200)\n";
fileInfo "license" "student";
createNode transform -n "pCube123";
	setAttr ".t" -type "double3" -3.7119621904286628 75.681977703169636 326.21921078991841 ;
	setAttr ".r" -type "double3" 0 90 0 ;
	setAttr ".s" -type "double3" 0.58986370321116777 0.50752301505313191 0.40589954240787274 ;
createNode mesh -n "pCubeShape123" -p "pCube123";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5 0.375 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 26 ".uvst[0].uvsp[0:25]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25 0.125 0.16725928 0.375 0.58274072 0.375 0.16725928
		 0.625 0.16725928 0.625 0.58274072 0.875 0.16725928 0.125 0.075993262 0.375 0.6740067
		 0.375 0.075993262 0.625 0.075993262 0.625 0.6740067 0.875 0.075993262;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 16 ".pt[0:15]" -type "float3"  0 0 1.7694842 0 0 1.7694842 
		0 0 1.236044 0 0 1.236044 0 0 1.5064536 0 0 1.5064536 0 0 0.97301388 0 0 0.97301388 
		0 -1.4808174 0.50737941 0 -1.4808174 2.2351186 0 -1.4808174 2.2351186 0 -1.4808174 
		0.50737941 0 0.71170592 0.5788303 0 0.71170592 2.1636677 0 0.71170592 2.1636677 0 
		0.71170592 0.5788303;
	setAttr -s 16 ".vt[0:15]"  -3.54633307 -4.18865681 4.44376898 3.54633307 -4.18865681 4.44376898
		 -3.54633307 4.18865681 4.44376898 3.54633307 4.18865681 4.44376898 -3.54633307 4.18865681 -4.44376898
		 3.54633307 4.18865681 -4.44376898 -3.54633307 -4.18865681 -4.44376898 3.54633307 -4.18865681 -4.44376898
		 -3.54633307 1.41607678 -4.44376898 -3.54633307 1.41607678 4.44376898 3.54633307 1.41607678 4.44376898
		 3.54633307 1.41607678 -4.44376898 -3.54633307 -1.64217925 -4.44376898 -3.54633307 -1.64217925 4.44376898
		 3.54633307 -1.64217925 4.44376898 3.54633307 -1.64217925 -4.44376898;
	setAttr -s 28 ".ed[0:27]"  0 1 0 2 3 0 4 5 0 6 7 0 0 13 0 1 14 0 2 4 0
		 3 5 0 4 8 0 5 11 0 6 0 0 7 1 0 8 12 0 9 2 0 8 9 1 10 3 0 9 10 1 11 15 0 10 11 1 11 8 1
		 12 6 0 13 9 0 12 13 1 14 10 0 13 14 1 15 7 0 14 15 1 15 12 1;
	setAttr -s 14 -ch 56 ".fc[0:13]" -type "polyFaces" 
		f 4 16 15 -2 -14
		mu 0 4 16 17 3 2
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 2 9 19 -9
		mu 0 4 4 5 18 15
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 18 -10 -8 -16
		mu 0 4 17 19 11 3
		f 4 14 13 6 8
		mu 0 4 14 16 2 13
		f 4 22 21 -15 12
		mu 0 4 20 22 16 14
		f 4 24 23 -17 -22
		mu 0 4 22 23 17 16
		f 4 26 -18 -19 -24
		mu 0 4 23 25 19 17
		f 4 -20 17 27 -13
		mu 0 4 15 18 24 21
		f 4 10 4 -23 20
		mu 0 4 12 0 22 20
		f 4 0 5 -25 -5
		mu 0 4 0 1 23 22
		f 4 -12 -26 -27 -6
		mu 0 4 1 10 25 23
		f 4 -28 25 -4 -21
		mu 0 4 21 24 7 6;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
createNode transform -n "pCube124";
	setAttr ".rp" -type "double3" -9.7197880744934082 75.681976318359375 326.21920776367187 ;
	setAttr ".sp" -type "double3" -9.7197880744934082 75.681976318359375 326.21920776367187 ;
createNode mesh -n "pCube124Shape" -p "pCube124";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 76 ".uvst[0].uvsp[0:75]" -type "float2" 0.375 0.16725928
		 0.625 0.16725928 0.625 0.25 0.375 0.25 0.125 0.16725928 0.1399048 0.16725929 0.13987476
		 0.16737273 0.14119375 0.24267033 0.35542578 0.24267033 0.35730574 0.16737273 0.35727602
		 0.16725928 0.125 0.25 0.375 0.075993262 0.625 0.075993262 0.64272398 0.16725928 0.64269423
		 0.16737273 0.64457422 0.24267033 0.85880625 0.24267033 0.86012524 0.16737273 0.8600952
		 0.16725929 0.875 0.16725928 0.875 0.25 0.625 0.5 0.375 0.5 0.625 0.58274072 0.375
		 0.58274072 0.125 0.075993262 0.1401058 0.075993262 0.1400122 0.084817179 0.35703668
		 0.075993262 0.35713348 0.084817171 0.375 0 0.625 0 0.64296329 0.075993262 0.64286655
		 0.084817171 0.85989422 0.075993262 0.875 0.075993262 0.85998785 0.084817179 0.625
		 0.6740067 0.375 0.6740067 0.125 0 0.35634416 0.0087882364 0.14059967 0.0087882364
		 0.375 0.75 0.625 0.75 0.625 1 0.375 1 0.875 0 0.85940033 0.0087882364 0.64365578
		 0.0087882364 0.375 0.16725928 0.375 0.25 0.625 0.25 0.625 0.16725928 0.375 0.075993262
		 0.37499997 0.16658361 0.625 0.16658361 0.625 0.075993262 0.375 0.5 0.625 0.5 0.375
		 0 0.375 0.073848046 0.625 0.073848046 0.625 0 0.375 0.58274072 0.625 0.58274072 0.375
		 0.75 0.375 1 0.625 1 0.625 0.75 0.37499997 0.5834164 0.375 0.6740067 0.625 0.6740067
		 0.625 0.5834164 0.375 0.67615193 0.625 0.67615193;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".clst[0].clsn" -type "string" "Colors";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 40 ".vt[0:39]"  -7.56542015 75.64911652 328.31106567 -7.56542015 75.64911652 324.12734985
		 -7.9709444 77.80781555 324.12734985 -7.9709444 77.80781555 328.31106567 -11.874156 75.64911652 328.31106567
		 -11.61727238 75.64911652 328.31106567 -11.6174593 75.65207672 328.31106567 -11.26482677 77.61658478 328.31106567
		 -8.22333622 77.61658478 328.31106567 -7.87070465 75.65207672 328.31106567 -7.87089157 75.64911652 328.31106567
		 -11.4686327 77.80781555 328.31106567 -7.59442234 75.20973969 328.31106567 -7.59442234 75.20973969 324.12734985
		 -7.87089157 75.64911652 324.12734985 -7.87070465 75.65207672 324.12734985 -8.22333622 77.61658478 324.12734985
		 -11.26482677 77.61658478 324.12734985 -11.6174593 75.65207672 324.12734985 -11.61727238 75.64911652 324.12734985
		 -11.874156 75.64911652 324.12734985 -11.4686327 77.80781555 324.12734985 -11.84515476 75.20973969 328.31106567
		 -11.58831215 75.20973969 328.31106567 -11.59223938 75.25222015 328.31106567 -7.89985132 75.20973969 328.31106567
		 -7.89592361 75.25222015 328.31106567 -7.75442123 73.55613708 328.31106567 -7.75442123 73.55613708 324.12734985
		 -7.89985132 75.20973969 324.12734985 -7.89592361 75.25222015 324.12734985 -11.58831215 75.20973969 324.12734985
		 -11.84515476 75.20973969 324.12734985 -11.59223938 75.25222015 324.12734985 -11.68515587 73.55613708 328.31106567
		 -8.035054207 73.74736786 328.31106567 -11.45310974 73.74736786 328.31106567 -11.68515587 73.55613708 324.12734985
		 -11.45310974 73.74736786 324.12734985 -8.035054207 73.74736786 324.12734985;
	setAttr -s 64 ".ed[0:63]"  0 1 1 1 2 0 2 3 0 3 0 0 4 5 1 5 6 0 6 7 0
		 7 8 0 8 9 0 9 10 0 10 0 1 3 11 0 11 4 0 12 13 1 13 1 0 0 12 0 1 14 1 14 15 0 15 16 0
		 16 17 0 17 18 0 18 19 0 19 20 1 20 21 0 21 2 0 21 11 0 20 4 1 22 23 1 23 24 0 24 5 0
		 4 22 0 25 12 1 10 26 0 26 25 0 27 28 0 28 13 0 12 27 0 13 29 1 29 30 0 30 14 0 31 32 1
		 32 20 0 19 33 0 33 31 0 32 22 1 34 27 0 25 35 0 35 36 0 36 23 0 22 34 0 34 37 0 37 28 0
		 37 32 0 31 38 0 38 39 0 39 29 0 8 16 0 15 9 1 30 26 1 7 17 0 39 35 0 6 18 1 38 36 0
		 24 33 1;
	setAttr -s 24 -ch 128 ".fc[0:23]" -type "polyFaces" 
		f 4 0 1 2 3
		mu 0 4 0 1 2 3
		f 10 4 5 6 7 8 9 10 -4 11 12
		mu 0 10 4 5 6 7 8 9 10 0 3 11
		f 4 13 14 -1 15
		mu 0 4 12 13 1 0
		f 10 16 17 18 19 20 21 22 23 24 -2
		mu 0 10 1 14 15 16 17 18 19 20 21 2
		f 4 -3 -25 25 -12
		mu 0 4 3 2 22 23
		f 4 -26 -24 26 -13
		mu 0 4 23 22 24 25
		f 5 27 28 29 -5 30
		mu 0 5 26 27 28 5 4
		f 5 31 -16 -11 32 33
		mu 0 5 29 12 0 10 30
		f 4 34 35 -14 36
		mu 0 4 31 32 13 12
		f 5 37 38 39 -17 -15
		mu 0 5 13 33 34 14 1
		f 5 40 41 -23 42 43
		mu 0 5 35 36 20 19 37
		f 4 -27 -42 44 -31
		mu 0 4 25 24 38 39
		f 8 45 -37 -32 46 47 48 -28 49
		mu 0 8 40 31 12 29 41 42 27 26
		f 4 50 51 -35 -46
		mu 0 4 43 44 45 46
		f 8 -52 52 -41 53 54 55 -38 -36
		mu 0 8 32 47 36 35 48 49 33 13
		f 4 -45 -53 -51 -50
		mu 0 4 39 38 44 43
		f 4 -9 56 -19 57
		mu 0 4 50 51 52 53
		f 6 -33 -10 -58 -18 -40 58
		mu 0 6 54 55 50 53 56 57
		f 4 -8 59 -20 -57
		mu 0 4 51 58 59 52
		f 6 -47 -34 -59 -39 -56 60
		mu 0 6 60 61 54 57 62 63
		f 4 -7 61 -21 -60
		mu 0 4 58 64 65 59
		f 4 -48 -61 -55 62
		mu 0 4 66 67 68 69
		f 6 -6 -30 63 -43 -22 -62
		mu 0 6 64 70 71 72 73 65
		f 6 -29 -49 -63 -54 -44 -64
		mu 0 6 71 74 66 69 75 72;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
createNode transform -n "pCube128";
	setAttr ".t" -type "double3" -10.382855173558417 75.68197770316965 326.21921078991835 ;
	setAttr ".r" -type "double3" 0 90 0 ;
	setAttr ".s" -type "double3" 0.060339820875003655 0.50752301505313191 0.40589954240787274 ;
createNode mesh -n "pCubeShape128" -p "pCube128";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5 0.375 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 26 ".uvst[0].uvsp[0:25]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25 0.125 0.16725928 0.375 0.58274072 0.375 0.16725928
		 0.625 0.16725928 0.625 0.58274072 0.875 0.16725928 0.125 0.075993262 0.375 0.6740067
		 0.375 0.075993262 0.625 0.075993262 0.625 0.6740067 0.875 0.075993262;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 16 ".pt[0:15]" -type "float3"  0 0 1.7694842 0 0 1.7694842 
		0 0 1.236044 0 0 1.236044 0 0 1.5064536 0 0 1.5064536 0 0 0.97301388 0 0 0.97301388 
		0 -1.4808174 0.50737941 0 -1.4808174 2.2351186 0 -1.4808174 2.2351186 0 -1.4808174 
		0.50737941 0 0.71170592 0.5788303 0 0.71170592 2.1636677 0 0.71170592 2.1636677 0 
		0.71170592 0.5788303;
	setAttr -s 16 ".vt[0:15]"  -3.54633307 -4.18865681 4.44376898 3.54633307 -4.18865681 4.44376898
		 -3.54633307 4.18865681 4.44376898 3.54633307 4.18865681 4.44376898 -3.54633307 4.18865681 -4.44376898
		 3.54633307 4.18865681 -4.44376898 -3.54633307 -4.18865681 -4.44376898 3.54633307 -4.18865681 -4.44376898
		 -3.54633307 1.41607678 -4.44376898 -3.54633307 1.41607678 4.44376898 3.54633307 1.41607678 4.44376898
		 3.54633307 1.41607678 -4.44376898 -3.54633307 -1.64217925 -4.44376898 -3.54633307 -1.64217925 4.44376898
		 3.54633307 -1.64217925 4.44376898 3.54633307 -1.64217925 -4.44376898;
	setAttr -s 28 ".ed[0:27]"  0 1 0 2 3 0 4 5 0 6 7 0 0 13 0 1 14 0 2 4 0
		 3 5 0 4 8 0 5 11 0 6 0 0 7 1 0 8 12 0 9 2 0 8 9 1 10 3 0 9 10 1 11 15 0 10 11 1 11 8 1
		 12 6 0 13 9 0 12 13 1 14 10 0 13 14 1 15 7 0 14 15 1 15 12 1;
	setAttr -s 14 -ch 56 ".fc[0:13]" -type "polyFaces" 
		f 4 16 15 -2 -14
		mu 0 4 16 17 3 2
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 2 9 19 -9
		mu 0 4 4 5 18 15
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 18 -10 -8 -16
		mu 0 4 17 19 11 3
		f 4 14 13 6 8
		mu 0 4 14 16 2 13
		f 4 22 21 -15 12
		mu 0 4 20 22 16 14
		f 4 24 23 -17 -22
		mu 0 4 22 23 17 16
		f 4 26 -18 -19 -24
		mu 0 4 23 25 19 17
		f 4 -20 17 27 -13
		mu 0 4 15 18 24 21
		f 4 10 4 -23 20
		mu 0 4 12 0 22 20
		f 4 0 5 -25 -5
		mu 0 4 0 1 23 22
		f 4 -12 -26 -27 -6
		mu 0 4 1 10 25 23
		f 4 -28 25 -4 -21
		mu 0 4 21 24 7 6;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
createNode groupId -n "groupId121";
	setAttr ".ihi" 0;
select -ne :time1;
	setAttr ".o" 7300;
	setAttr ".unw" 7300;
select -ne :renderPartition;
	setAttr -s 49 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 29 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderUtilityList1;
	setAttr -s 144 ".u";
select -ne :defaultRenderingList1;
	setAttr -s 2 ".r";
select -ne :lightList1;
select -ne :defaultTextureList1;
	setAttr -s 16 ".tx";
select -ne :initialShadingGroup;
	setAttr -s 213 ".dsm";
	setAttr ".ro" yes;
	setAttr -s 85 ".gn";
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :initialMaterialInfo;
select -ne :defaultRenderGlobals;
	setAttr ".mcfr" 25;
	setAttr ".edl" no;
	setAttr ".outf" 3;
	setAttr ".an" yes;
	setAttr ".fs" 1;
	setAttr ".ef" 326;
	setAttr ".me" yes;
	setAttr ".ep" 5;
	setAttr ".pff" yes;
	setAttr ".ifp" -type "string" "LostAnimation";
select -ne :defaultRenderQuality;
	setAttr ".rfl" 10;
	setAttr ".rfr" 10;
	setAttr ".sl" 10;
	setAttr ".eaa" 0;
	setAttr ".ufil" yes;
	setAttr ".ss" 2;
select -ne :defaultResolution;
	setAttr ".w" 1920;
	setAttr ".h" 1080;
	setAttr ".pa" 1;
	setAttr ".dar" 1.7777777910232544;
select -ne :defaultLightSet;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
	setAttr ".hwfr" 25;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
select -ne :defaultHardwareRenderGlobals;
	setAttr ".res" -type "string" "ntsc_4d 646 485 1.333";
select -ne :ikSystem;
	setAttr -s 4 ".sol";
connectAttr "groupId121.id" "pCube124Shape.ciog.cog[0].cgid";
connectAttr "pCubeShape123.iog" ":initialShadingGroup.dsm" -na;
connectAttr "pCube124Shape.iog" ":initialShadingGroup.dsm" -na;
connectAttr "pCube124Shape.ciog.cog[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape128.iog" ":initialShadingGroup.dsm" -na;
// End of Door_L_Template.ma
