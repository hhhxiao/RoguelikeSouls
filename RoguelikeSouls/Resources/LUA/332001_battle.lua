LuaP		�	�h��}A<       @N:\FRPG\data\INTERROOT_x64\script\ai\out\332001_battle.lua        &                     	   
                                       R      �   �   �   �   [   �   �   9    @  >  G  E  ^  O  ^            Att3000_Dist_min    %          Att3000_Dist_max    %          Att3001_Dist_min    %          Att3001_Dist_max    %          Att3003_Dist_min 	   %          Att3003_Dist_max 
   %          Att3005_Dist_min    %          Att3005_Dist_max    %          Att3006_Dist_min    %          Att3006_Dist_max    %          Att3007_Dist_min    %          Att3007_Dist_max    %                 REGISTER_GOAL #       GOAL_ThreeHaoriBunsin332001_Battle        ThreeHaoriBunsin332001Battle               I@      @       @      $@       REGISTER_GOAL_NO_UPDATE       �?       OnIf_332001 &       ThreeHaoriBunsin332001Battle_Activate ,       ThreeHaoriBunsin332001_ActAfter_AdjustSpace #       ThreeHaoriBunsin332001StepForLeave $       ThreeHaoriBunsin332001Battle_Update '       ThreeHaoriBunsin332001Battle_Terminate &       ThreeHaoriBunsin332001Battle_Interupt                 U               "   "   "   "   #   #   #   #   $   $   $   $   &   '   (   +   +   ,   -   .   .   1   1   2   3   4   4   8   9   :   ?   ?   ?   B   B   B   C   C   C   C   C   C   C   C   C   C   C   C   G   G   H   H   H   H   H   H   H   H   H   H   J   J   K   K   K   K   K   K   K   K   K   K   N   N   N   N   N   N   N   N   N   R   
          ai     T          goal     T          codeNo     T          targetDist    T          fate    T          fate2    T          fate3    T          AA01Per    T          AA02Per    T          AA03Per    T                 GetDist        TARGET_ENE_0        GetRandam_Int       �?      Y@              $@      4@      T@      @       AddSubGoal        GOAL_COMMON_Wait        GetRandam_Float       �?      I@       GOAL_COMMON_SpinStep      �@       AI_DIR_TYPE_B      �R@     ��@       AI_DIR_TYPE_L      ��@       AI_DIR_TYPE_R     U   �> E  ��? �   � ? �   � ? �   	� A A A 	� � � � A �  	� ׀� � � A �  	� � A �  	�  � �� �
� �� � 
� �A �  A � A A A A Y 
� � T� � 
� �  E  A E A Y�
� � T� � 
� � � E  A  A Y�
� � 
� � A E  A � A Y�
�          [    �   ^   ^   ^   `   `   `   `   a   a   a   a   b   b   b   b   c   c   c   c   d   d   d   d   f   f   f   g   g   g   i   i   i   l   o   p   q   r   s   t   u   v   {   {   |   |   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �             ai     �          goal     �          targetDist    �          fate    �          fate2    �          fate3    �          fate4    �          fate5    �          activeBreathChr    �          DisAppear_flag    �          role     �          GetWellSpace_Odds !   �   	       Act01Per "   �   	       Act02Per #   �   	       Act03Per $   �   	       Act04Per %   �   	       Act05Per &   �   	       Act06Per '   �   	       Act07Per (   �   	       Act08Per )   �          fateAct f   �          fateGWS �   �             Att3000_Dist_max        Att3001_Dist_max        Att3003_Dist_max '          GetDist        TARGET_ENE_0        GetRandam_Int       �?      Y@       GetEventRequest                GetTeamOrder        ORDER_TYPE_Role        ROLE_TYPE_Kankyaku       >@     �Q@       ROLE_TYPE_Torimaki        @      4@      @      9@      .@      @      $@      @      N@       AddSubGoal        GOAL_COMMON_ApproachTarget        TARGET_SELF       �       GOAL_COMMON_Attack      p�@
       DIST_None      r�@     v�@       GOAL_COMMON_AttackTunableSpin      |�@     �V@     ~�@#       ThreeHaoriBunsin332001StepForLeave        GOAL_COMMON_NonspinningAttack      ��@,       ThreeHaoriBunsin332001_ActAfter_AdjustSpace     �   �> E  ��? �   � ? �   � ? �   � ? �   	� ? �  	 
� �? � 
���? 	�  ��	K@ 
 ��
� � � � � � � � � U� T �  �� E  � �� � � � � �	�   � �? � � � � �� ��� � � � � � �� ��� T� � � �  A �� � � �� � � � � �   T� � � � A A A ? �  L��̃�L���̄� 
 �� � � � E     � A Y�� � � � E   � Y  T� LW
 �� � � � E  �  � A Y�� � � A E   � Y  �� L��
W
 �� � � � E    � A Y�� � � � E   � Y  � L��
̃
W
 �� � � �  E   �  A Y� � L��
̃
�
W
 �� � � � � E   �  A Y� �� L��
̃
�
L�
W
 T� �     � Y�� �� L��
̃
�
L�
��
W
 T� � 	 � A	 E   � Y �  �  ? �   � ׂ
 � � �	     � Y��          �         �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �   �             ai               goal               targetDist              fate              fate2              fate3                     GetDist        TARGET_ENE_0        GetRandam_Int       �?      Y@       AddSubGoal        GOAL_COMMON_Wait        GetRandam_Float       @       TARGET_NONE                GOAL_COMMON_If       $@        �> E  ��? �   � ? �   � ? �   � ˿ � K@ 	�   � 	E 
� � � Y ˿ �  	� 
Y��              �                 	  	  	  	  
  
  
  
                                                                                                                                                                                                                          !  !  !  !  !  !  !  !  "  "  "  "  "  "  "  "  "  "  $  $  $  $  $  $  $  $  %  %  %  %  %  %  %  %  %  %  '  '  '  '  '  '  '  '  (  (  (  (  (  (  (  (  (  (  *  *  *  *  *  *  *  *  +  +  +  +  +  +  +  +  +  +  -  -  -  -  -  -  -  -  .  .  .  .  .  .  .  .  .  .  0  0  0  0  0  0  0  0  1  1  1  1  1  1  1  1  1  1  5  5  5  5  5  5  5  5  5  9            ai     �          goal     �          targetDist    �          fate    �          fate2    �          fate3    �       &          GetDist        TARGET_ENE_0        GetRandam_Int       �?      Y@       IsInsideMsbRegion        TARGET_SELF        AI_DIR_TYPE_F        @    ��3A       AddSubGoal        GOAL_COMMON_SpinStep       $@     ��@              @       AI_DIR_TYPE_L      ��@       AI_DIR_TYPE_R      ��@       AI_DIR_TYPE_B      ��@      @     0�@      @     @�@     H�@     8�@      @     �@       @     ��@     ��@     ��@       GOAL_COMMON_AttackTunableSpin      ~�@
       DIST_None      �V@    �   �> E  ��? �   � ? �   � ? �   � �? � � 	 
A �  T� � �  	A 
E  � � � Y��3� �? �  	 
A �  T� � �  	A 
E  �  � Y�/� �? � � 	 
A �  T� � �  	� 
E  � � � Y��*� �? �  	 
A �  T� � �  	A 
E  �  � Y�&� �? � � 	� 
A �  T� � �  	� 
E  � �  Y��!� �? �  	� 
A �  T� � �  	A 
E  �   Y�� �? � � 	� 
A �  T� � �  	� 
E  � �  Y��� �? �  	� 
A �  T� � �  	� 
E  �   Y�� �? �  	 
A �  T� � �  	A 
E  �  � Y��� �? �  	 
A �  T� � �  	� 
E  �  � Y�� �? � � 	 
A �  T� � �  	 
E  � � � Y��� �? � � 	 
A �  T� � �  	A 
E  � � � Y�� � �  	� 
E  	 �  A	 Y��          >       ?  ?  @            ai               goal                      GOAL_RESULT_Continue           �          E       G            ai                goal                        �          O       Q  Q  Q  T  T  T  T  T  U  U  V  V  V  V  V  V  V  V  W  W  \  \  ^            ai               goal               hprate              
       GetHpRate        TARGET_SELF        IsInterupt        INTERUPT_Damaged        ClearSubGoal        AddSubGoal        GOAL_COMMON_NonspinningAttack       4@     ��@       TARGET_ENE_0 
       DIST_None                �> E  ��? �  ����� �� Y ˿ � �  E � 	� 
Y �     �  &      E  �  Y� �    �   �  A �  � �  � 	�  
�  E  A Y�"  � b   �   �  � � �   �  G " � b � �  �  