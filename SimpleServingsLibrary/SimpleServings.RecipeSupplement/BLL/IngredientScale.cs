using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using SimpleServingsLibrary.Shared;

namespace SimpleServingsLibrary.RecipeSupplement
{
    public class IngredientScale
    {
        private int scaleID;
        public int ScaleID 
        {
            set { scaleID = value; }
            get { return scaleID; }
        }

        private int measureUnit;
        public int MeasureUnit 
        {
            set { measureUnit = value; }
            get { return measureUnit; }
        }

        private int scaleTypeId;
        public int ScaleTypeId 
        {
            set { scaleTypeId = value; }
            get { return scaleTypeId; }
        }

        private int scaleMeasureUnitID;
        public int ScaleMeasureUnitID {
            set { scaleMeasureUnitID = value; }
            get { return scaleMeasureUnitID; }
        }

        private int differentAmount;
        public int DifferentAmount 
        {
            set { differentAmount = value; }
            get { return differentAmount; }
        }

        private bool isActive;
        public bool IsActive 
        {
            set { isActive = value; }
            get { return isActive; }
        }

        internal static IngredientScale PopIngredientScale(SqlDataReader dr)
        {
            using (dr)
            {
                IngredientScale ingredientScale = new IngredientScale();
                if (dr.Read())
                {
                    ingredientScale.ScaleID = Convert.ToInt32(dr["ScaleID"]);
                    ingredientScale.MeasureUnit = Convert.ToInt32(dr["MeasureUnitId"]);
                    ingredientScale.ScaleTypeId = Convert.ToInt32(dr["ScaleTypeID"]);
                    ingredientScale.ScaleMeasureUnitID = Convert.ToInt32(dr["ScaleMeasureUnitID"]);
                    ingredientScale.DifferentAmount = Convert.ToInt32(dr["DifferentAmount"]);
                    ingredientScale.IsActive = Convert.ToBoolean(dr["IsActive"]);
                }

                return ingredientScale;
            }
        }

        internal static int PopYield(SqlDataReader dr)
        {
            using (dr)
            {
                int yield = 1;
                if (dr.Read())
                {
                    yield = Convert.ToInt32(dr["Yield"]);
                }
                return yield;
            }
        }

        internal static IngredientScales PopIngredientScales(SqlDataReader dr)
        {
            using (dr)
            {
                IngredientScales ingredientScales = new IngredientScales();
                
                while (dr.Read())
                {
                    IngredientScale ingredientScale = new IngredientScale();

                    ingredientScale.ScaleID = Convert.ToInt32(dr["ScaleID"]);
                    ingredientScale.MeasureUnit = Convert.ToInt32(dr["MeasureUnitId"]);
                    ingredientScale.ScaleTypeId = Convert.ToInt32(dr["ScaleTypeID"]);
                    ingredientScale.ScaleMeasureUnitID = Convert.ToInt32(dr["ScaleMeasureUnitID"]);
                    ingredientScale.DifferentAmount = Convert.ToInt32(dr["DifferentAmount"]);
                    ingredientScale.IsActive = Convert.ToBoolean(dr["IsActive"]);

                    ingredientScales.Add(ingredientScale);
                }

                return ingredientScales;
            }
        }
        internal static void GetDownCastScaleIngredient(CastingInfo downCastInfo)
        {

            IngredientScale ingredientScale = PopIngredientScale(IngredientScaleDB.GetDownCastScaleIngredient(downCastInfo.MeasureUnit));
            if (ingredientScale.IsActive)
            {
                //amount *= ingredientScale.differentAmount;
                downCastInfo.Amount = downCastInfo.Amount * ingredientScale.differentAmount;
                downCastInfo.MeasureUnit = ingredientScale.ScaleMeasureUnitID;
                GetDownCastScaleIngredient(downCastInfo); 
            }
        }

        internal static void GetUpCastScaleIngredient(CastingInfo upCastInfo)
        {
            IngredientScale ingredientScale = PopIngredientScale(IngredientScaleDB.GetUpCastScaleIngredient(upCastInfo.MeasureUnit));
            if (ingredientScale.IsActive)
            {

                if (upCastInfo.Amount / ingredientScale.differentAmount >= 1)
                {
                    //RecipeIngredient recipeIngredient = new RecipeIngredient();
                    //recipeIngredient.MeasureUnit = ingredientScale.ScaleMeasureUnitID;
                    if (upCastInfo.Amount % ingredientScale.differentAmount != 0)
                    {
                        upCastInfo.IngredientScaleString = (upCastInfo.Amount % ingredientScale.differentAmount) +" "+ Code.DecodeCode(ingredientScale.MeasureUnit) +" "+ upCastInfo.IngredientScaleString;
                    }
                    upCastInfo.Amount = Math.Floor(upCastInfo.Amount / ingredientScale.differentAmount);
                    upCastInfo.MeasureUnit = ingredientScale.ScaleMeasureUnitID;
                }
                else
                {
                    upCastInfo.IngredientScaleString = upCastInfo.Amount +" "+ Code.DecodeCode(ingredientScale.MeasureUnit) +" "+ upCastInfo.IngredientScaleString;
                    return;
                }
                GetUpCastScaleIngredient(upCastInfo);
            }
            else
            {
                if ((upCastInfo.IngredientScaleString == "" || upCastInfo.IngredientScaleString == null) && upCastInfo.Amount <= 0)
                {
                    return;
                }
                upCastInfo.IngredientScaleString = upCastInfo.Amount  +" " + Code.DecodeCode(upCastInfo.MeasureUnit) +" "+ upCastInfo.IngredientScaleString;
            }
        }

        //example of upcast before
        /*
         while ((select @intAmount/DifferenceAmountFromUpper from tblConversion where @measureUnit = CurrentMesurement) >= 1)
	BEGIN
		
		if((select @intAmount%DifferenceAmountFromUpper from tblConversion where @measureUnit = CurrentMesurement) != 0)
		set @outPutResult = cast((select @intAmount%DifferenceAmountFromUpper from tblConversion where @measureUnit = CurrentMesurement)as varchar) +' '+ (select CodeDescription from tblCode where CodeType ='IngredientMeasureUnit' and CodeID=@measureUnit)+ @outPutResult 
		
		
		set @intAmount = (select @intAmount/DifferenceAmountFromUpper from tblConversion where @measureUnit = CurrentMesurement)
		set @measureUnit = (select UpperMesurement from tblConversion where @measureUnit = CurrentMesurement)
		did not do this part if((select UpperMesurement from tblConversion where @measureUnit = CurrentMesurement) is NULL)
		begin
		set @outPutResult = cast(@amount as varchar) +' '+ (select CodeDescription from tblCode where CodeType ='IngredientMeasureUnit' and CodeID=@measureUnit)+ ' and ' +@outPutResult 
			break
		end
	End
End
else 
begin
	if(@amount > 1)
	Begin
	set @outPutResult = @outPutResult + cast(@amount as varchar) +' '+ (select CodeDescription from tblCode where CodeType ='IngredientMeasureUnit' and CodeID=@measureUnit)
	End
	else
	begin
	set @outPutResult = @outPutResult + cast(@amount as varchar) +' '+ (select CodeDescription from tblCode where CodeType ='IngredientMeasureUnit' and CodeID=@measureUnit)
	end
end
         */

        public static CastingInfo GetIngredientScales(double amount, int measureUnit)
        {
            CastingInfo castingInfo = new CastingInfo();
            castingInfo.Amount = amount;
            castingInfo.MeasureUnit = measureUnit;
            GetDownCastScaleIngredient(castingInfo);
            castingInfo.Amount = Math.Round(castingInfo.Amount);
            GetUpCastScaleIngredient(castingInfo);
            //return (PopIngredientScales(IngredientScaleDB.ScaleIngredients(amount, measureUnit)));
            return castingInfo;
        }


        public static List<string> ScaleIngredients(int recipeID, int scaleTo)
        {
            //IngredientScales ingredientScales = IngredientScale.GetIngredientScales();
            RecipeIngredients recipeIngredients = RecipeIngredient.GetRecipeIngredientByRecipeID(recipeID);

            int yeild = GetYieldByRecipeID(recipeID);
            List<string> scaleIngredients = new List<string>();
            foreach (RecipeIngredient recipeIngredient in recipeIngredients)
            {
                //if(R)

                recipeIngredient.Quantity = (recipeIngredient.Quantity / yeild) * scaleTo;
                scaleIngredients.Add(GetIngredientScales(recipeIngredient.Quantity, recipeIngredient.MeasureUnit).IngredientScaleString + recipeIngredient.Description);
            }
            return scaleIngredients;
        }

        public static int GetYieldByRecipeID(int recipeId)
        {
            return PopYield(IngredientScaleDB.GetYieldByRecipeID(recipeId));
        }
    }
    public class CastingInfo
    {
        private double amount;
        private int measureUnit;
        private string ingredientScaleString;
        public string IngredientScaleString
        {
            set { ingredientScaleString = value; }
            get { return ingredientScaleString; }
        }
        public double Amount
        {
            set{ amount = value;}
            get{ return amount;}
        }

        public int MeasureUnit {
            set { measureUnit = value; }
            get { return measureUnit; }
        }
    }

    public class IngredientScales : List<IngredientScale> 
    {
    }
}
